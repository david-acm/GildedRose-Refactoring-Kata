namespace GildedRoseKata;

public class BackstagePasses(Item item) : ItemType(item)
{
  protected override int QualityIncreasesBy => ItemSellIn switch
  {
    < 0  => -ItemQuality,
    < 5  => 3,
    < 10 => 2,
    _    => 1
  };

}
