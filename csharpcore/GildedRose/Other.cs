namespace GildedRoseKata;

public class Other(Item item) : ItemType
{
  public override Item Item { get; } = item;
  public override void UpdateItem()
  {
    --Item.SellIn;
    var qualityIncrease = Item.SellIn switch
    {
      < 0 => -2,
      _   => -1
    };

    Item.Quality = int.Max(Item.Quality + qualityIncrease, 0);
  }
}