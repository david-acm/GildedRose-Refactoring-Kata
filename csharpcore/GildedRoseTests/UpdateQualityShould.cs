using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class UpdateQualityShould
{
  [Theory]
  [InlineData("Foo", 10, 10)]
  public void DecreaseQualityDaily(
    string name, int quality, int sellIn)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.Quality.Should().Be(quality - 1);
  }

  [Theory]
  [InlineData("Foo", 10, 10)]
  public void DecreaseSellInDaily(
    string name, int quality, int sellIn)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.SellIn.Should().Be(sellIn - 1);
  }

  [Theory]
  [InlineData("Foo", 5, 0)]
  public void DecreaseQualityTwiceAsFastWhen(
    string name, int quality, int sellIn)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.Quality.Should().Be(quality - 2);
  }

  [Theory]
  [InlineData("Foo", 0, -1)]
  public void NotLowerQualityBelowZero(
    string name, int quality, int sellIn)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.Quality.Should().BeGreaterThanOrEqualTo(0);
  }

  [Theory]
  [InlineData("Aged Brie", 49, 10)]
  [InlineData("Aged Brie", 50, 10)]
  public void NotIncreaseAbove50(
    string name, int quality, int sellIn)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.Quality.Should().Be(50);
  }

  [Theory]
  [InlineData("Sulfuras, Hand of Ragnaros", 49, 10)]
  public void DecreaseQualityOrSellInWhenItemIsSulfuras(
    string name, int quality, int sellIn)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.Quality.Should().Be(quality);
    itemType.Item.SellIn.Should().Be(sellIn);
  }

  [Theory]
  [InlineData("Backstage passes to a TAFKAL80ETC concert", 11, 0, 1)]
  [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 0, 2)]
  [InlineData("Backstage passes to a TAFKAL80ETC concert", 3, 0, 3)]
  [InlineData("Backstage passes to a TAFKAL80ETC concert", 0, 5, 0)]
  public void IncreaseQualityAsSellInApproachesWhenItemIsBackstagePasses(
    string name, int sellIn, int quality, int expectedQuality)
  {
    // Given
    var itemType = ItemType
      .FromItem(new Item(name, quality, sellIn));

    // When
    itemType.UpdateItem();

    // Then
    itemType.Item.Quality.Should().Be(expectedQuality);
  }
}
