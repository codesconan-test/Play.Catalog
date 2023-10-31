using MongoDB.Driver;
using Play.Catalog.Data.Interfaces;
using Play.Catalog.Entities;
using Play.Catalog.Repositories.Interfaces;

namespace Play.Catalog.Repositories;

/// <summary>
/// Repository class for managing items.
/// </summary>
public class ItemRepository : IItemRepository
{
    private readonly IItemContext _context;

    public ItemRepository(IItemContext context)
    {
        this._context = context;
    }

    /// <summary>
    /// Retrieves all items from the database.
    /// </summary>
    /// <returns>An enumerable collection of Item objects.</returns>
    public async Task<IEnumerable<Item>> GetAsync()
    {
        return await _context.Items.Find(item => true).ToListAsync();
    }

    /// <summary>
    /// Creates a new item asynchronously.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task CreateAsync(Item item)
    {
        await _context.Items.InsertOneAsync(item);
    }

    /// <summary>
    /// Retrieves an item from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The retrieved item, or null if it doesn't exist.</returns>
    public async Task<Item?> GetAsync(Guid id)
    {
        return await _context.Items.Find(item => item.Id == id).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Updates an item in the database.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="item">The item to update.</param>
    /// <returns>A boolean indicating whether the update was successful.</returns>
    public async Task<bool> UpdateAsync(Guid id, Item item)
    {
        var updateResult = await _context.Items.ReplaceOneAsync(filter: item1 => item1.Id == id, replacement: item);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    /// <summary>
    /// Deletes an item from the database.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var deleteResult = await _context.Items.DeleteOneAsync(item => item.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}