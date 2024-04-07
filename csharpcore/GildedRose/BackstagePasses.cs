namespace GildedRoseKata;

public class BackstagePasses(Item item) : ItemType
{
  public override Item Item { get; } = item;

  public override void UpdateItem()
  {
    Item.SellIn--;
    var qualityIncrease = Item.SellIn switch
    {
      < 0  => -Item.Quality,
      < 5  => 3,
      < 10 => 2,
      _    => 1
    };

    Item.Quality = int.Min(Item.Quality + qualityIncrease, 50);
  }
}