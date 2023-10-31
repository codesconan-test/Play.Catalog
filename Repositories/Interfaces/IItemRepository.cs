using Play.Catalog.Entities;

namespace Play.Catalog.Repositories.Interfaces;

public interface IItemRepository
{
    /// <summary>
    /// Retrieves all items asynchronously.
    /// </summary>
    /// <returns>An enumerable collection of items.</returns>
    Task<IEnumerable<Item>> GetAsync();
    
    
    /// <summary>
    /// Creates a new item asynchronously.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateAsync(Item item);
    
    // read
    /// <summary>
    /// Retrieves an item with the specified ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the item to retrieve.</param>
    /// <returns>The retrieved item, or null if no item with the specified ID was found.</returns>
    Task<Item?> GetAsync(Guid id);
    
    // update
    /// <summary>
    /// Updates an existing item in the repository.
    /// </summary>
    /// <param name="id">The ID of the item to update.</param>
    /// <param name="item">The updated item.</param>
    /// <returns>A boolean indicating whether the update was successful.</returns>
    Task<bool> UpdateAsync(Guid id, Item item);
    
    // delete
    /// <summary>
    /// Deletes an item with the specified ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <returns>A task that represents the asynchronous delete operation. The task result contains a boolean value indicating whether the delete operation was successful.</returns>
    Task<bool> DeleteAsync(Guid id);
}