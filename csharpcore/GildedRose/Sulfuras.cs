namespace GildedRoseKata;

public class Sulfuras(Item item) : ItemType
{
  public override Item Item { get; } = item;
  public override void UpdateItem()
  {
  }
}