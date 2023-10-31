using MongoDB.Driver;
using Play.Catalog.Entities;

namespace Play.Catalog.Data.Seeds;

/// <summary>
/// Class for seeding the item collection in the database with preconfigured items.
/// </summary>
public class ItemContextSeed
{
  /// <summary>
  /// Seeds the item collection with preconfigured items if it is empty.
  /// </summary>
  /// <param name="itemCollection">The MongoDB collection of items.</param>
  public static void SeedData(IMongoCollection<Item> itemCollection)
  {
    var existItem = itemCollection.Find(p => true).Any();
    if (!existItem)
    {
      itemCollection.InsertManyAsync(GetPreconfiguredItems());
    }
  }

  /// <summary>
  /// Returns a list of preconfigured items.
  /// </summary>
  /// <returns>A list of preconfigured items.</returns>
  private static IEnumerable<Item> GetPreconfiguredItems()
  {
    return new List<Item>
    {
      new()
      {
        Name = "Potion",
        Description = "Restore a small amount of HP.",
        Price = 5,
        CreatedDate = DateTimeOffset.UtcNow.Date
      },
      new()
      {
        Name = "Antidote",
        Description = "Cures poison.",
        Price = 7,
        CreatedDate = DateTimeOffset.UtcNow.Date
      },
      new()
      {
        Name = "Bronze Sword",
        Description = "Deals a small amount of damage.",
        Price = 10,
        CreatedDate = DateTimeOffset.UtcNow.Date
      },
      new()
      {
        Name = "Bronze Shield",
        Description = "Provides a small amount of protection.",
        Price = 10,
        CreatedDate = DateTimeOffset.UtcNow.Date
      }
    };
  }
}