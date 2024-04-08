namespace GildedRoseKata;

public class Sulfuras(Item item) : ItemType(item)
{
  protected override int QualityIncreasesBy => 0;
  protected override int SellInDecreasesBy  => 0;
}
