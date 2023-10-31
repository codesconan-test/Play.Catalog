using MongoDB.Driver;
using Play.Catalog.Data.Interfaces;
using Play.Catalog.Data.Seeds;
using Play.Catalog.Entities;

namespace Play.Catalog.Data.Contexts;

/// <summary>
/// Represents the MongoDB context for the Item entity.
/// </summary>
public class ItemContext : IItemContext
{
    public ItemContext()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("Catalog");
        
        Items = database.GetCollection<Item>("Items");
        
        ItemContextSeed.SeedData(Items);
    }
    


    /// <summary>
    /// Represents a MongoDB collection of items.
    /// </summary>
    public IMongoCollection<Item> Items { get; }
}