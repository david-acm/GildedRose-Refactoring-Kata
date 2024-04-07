namespace GildedRoseKata;

public class Conjured(Item item) : ItemType
{
  public override Item Item { get; } = item;
  public override void UpdateItem()
  {
    Item.SellIn--;
    
    Item.Quality = int.Min(Item.Quality - 2, 50);
  }
}
