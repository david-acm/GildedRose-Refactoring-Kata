namespace GildedRoseKata;

public class Other(Item item) : ItemType(item)
{
  protected override int QualityIncreasesBy => ItemSellIn switch
  {
    < 0 => -2,
    _   => -1
  };
}
