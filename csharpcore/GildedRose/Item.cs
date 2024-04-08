using System;

namespace GildedRoseKata;

public class Item
{
  public Item()
  {
  }
  public Item(string name, int quality, int sellIn)
  {
    Name    = name;
    Quality = quality;
    SellIn  = sellIn;
  }
  
  public string Name    { get; set; }
  public int    SellIn  { get; set; }
  public int    Quality { get; set; }
}