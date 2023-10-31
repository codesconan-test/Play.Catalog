using Play.Catalog.Entities;

namespace Play.Catalog.Repositories.Interfaces;

/// <summary>
/// Interface for a repository that handles CRUD operations for entities that implement IEntity.
/// </summary>
/// <typeparam name="T">The type of entity that implements IEntity.</typeparam>
public interface IItemRepository<T> where T : IEntity
{
    
    Task<IEnumerable<T>> GetAsync();


    Task CreateAsync(T item);
    
    // read
    Task<T?> GetAsync(Guid id);
    
    // update
    Task<bool> UpdateAsync(Guid id, T item);
    
    // delete
    Task<bool> DeleteAsync(Guid id);
}