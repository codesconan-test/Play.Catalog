using MongoDB.Driver;
using Play.Catalog.Entities;

namespace Play.Catalog.Data.Interfaces;

public interface IItemContext
{
    /// <summary>
    /// Represents a MongoDB collection of items.
    /// </summary>
    IMongoCollection<Item> Items { get; }
    
}