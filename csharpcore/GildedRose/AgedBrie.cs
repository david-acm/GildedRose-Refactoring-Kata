namespace GildedRoseKata;

public class AgedBrie(Item item) : ItemType(item)
{
  protected override int QualityIncreasesBy => ItemSellIn switch
  {
    < 0 => 2,
    _   => 1
  };
}
