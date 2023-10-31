using MongoDB.Driver;
using Play.Catalog.Data.Interfaces;
using Play.Catalog.Data.Seeds;
using Play.Catalog.Entities;

namespace Play.Catalog.Data.Contexts;

/// <summary>
/// Represents the MongoDB context for the Item entity.
/// </summary>
public class ItemContext : IItemContext<Item>
{
    public ItemContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        
        Items = database.GetCollection<Item>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        
        ItemContextSeed.SeedData(Items);
    }
    


    /// <summary>
    /// Represents a MongoDB collection of items.
    /// </summary>
    public IMongoCollection<Item> Items { get; }
}