using System;

namespace GildedRoseKata;

public class Item
{
  public string Name    { get; set; }
  public int    SellIn  { get; set; }
  public int    Quality { get; set; }
  public void UpdateItem()
  {
    var isAgedBrie        = Name == "Aged Brie";
    var isBackstagePasses = Name == "Backstage passes to a TAFKAL80ETC concert";
    var isSulfuras        = Name == "Sulfuras, Hand of Ragnaros";
    int qualityIncrease;

    if (isAgedBrie)
    {
      SellIn--;
      qualityIncrease = SellIn switch
      {
        < 0 => 2,
        _   => 1
      };

      Quality = int.Min(Quality + qualityIncrease, 50);

      return;
    }

    if (isBackstagePasses)
    {
      SellIn--;
      qualityIncrease = SellIn switch
      {
        < 0  => -Quality,
        < 5  => 3,
        < 10 => 2,
        _    => 1
      };

      Quality = int.Min(Quality + qualityIncrease, 50);

      return;
    }

    if (isSulfuras)
    {
      return;
    }

    --SellIn;
    qualityIncrease = SellIn switch
    {
      < 0 => -2,
      _   => -1
    };
    
    Quality = int.Max(Quality + qualityIncrease, 0);
  }
}
