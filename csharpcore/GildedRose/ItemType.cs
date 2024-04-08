using System;

namespace GildedRoseKata;

public abstract class ItemType(Item item)
{
  private            Item Item               { get; } = item;
  public             int  ItemQuality        => Item.Quality;
  public             int  ItemSellIn         => Item.SellIn;
  protected abstract int  QualityIncreasesBy { get; }
  protected virtual  int  SellInDecreasesBy  => 1;

  public void UpdateItem()
  {
    DecreaseSellIn();
    if (QualityIncreasesBy is 0)
      return;
    Item.Quality = Math.Clamp(Item.Quality + QualityIncreasesBy, 0, 50);
  }

  private void DecreaseSellIn() => Item.SellIn = Item.SellIn - SellInDecreasesBy;

  public static ItemType FromItem(Item item) => item.Name switch
  {
    "Aged Brie"                                 => new AgedBrie(item),
    "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
    "Sulfuras, Hand of Ragnaros"                => new Sulfuras(item),
    "Conjured"                                  => new Conjured(item),
    _                                           => new Other(item)
  };
}
