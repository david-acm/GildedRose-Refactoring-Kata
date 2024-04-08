namespace GildedRoseKata;

public class Conjured(Item item) : ItemType(item)
{
  protected override int QualityIncreasesBy => -2;
}
