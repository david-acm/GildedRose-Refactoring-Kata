namespace GildedRoseKata;

public abstract class ItemType
{
  public abstract Item Item { get; }
  public abstract void UpdateItem();

  public static ItemType FromItem(Item item) => item.Name switch
  {
    "Aged Brie"                                 => new AgedBrie(item),
    "Backstage passes to a TAFKAL80ETC concert" => new BackstagePasses(item),
    "Sulfuras, Hand of Ragnaros"                => new Sulfuras(item),
    "Conjured"                                  => new Conjured(item),
    _                                           => new Other(item)
  };
}