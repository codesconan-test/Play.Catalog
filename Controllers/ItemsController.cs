using Microsoft.AspNetCore.Mvc;
using Play.Catalog.DTOs;
using Play.Catalog.Entities;
using Play.Catalog.Repositories.Interfaces;

namespace Play.Catalog.Controllers;

/// <summary>
/// Controller for managing items.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class ItemsController : ControllerBase
{

   // repository 
   private readonly IItemRepository _repository;

    public ItemsController(IItemRepository repository)
    {
        _repository = repository?? throw new ArgumentNullException(nameof(repository));
    }
    
    /// <summary>
    /// Retrieves all items from the repository.
    /// </summary>
    /// <returns>An enumerable collection of ItemDto objects.</returns>
    [HttpGet]
    public async Task<IEnumerable<Dtos.ItemDto>> GetAsync()
    {
        var items = await _repository.GetAsync();
        
        return items.Select(item => item.AsDto());
    }
    
    // get item by id
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Dtos.ItemDto>> GetByIdAsync(Guid id)
    {
        var item = await _repository.GetAsync(id);
        
        if (item is null)
        {
            return NotFound();
        }
        
        return item.AsDto();
    }
    
    
    // create item
    [HttpPost]
    public async Task<ActionResult<Dtos.ItemDto>> PostAsync(Dtos.CreateItemDto createItemDto)
    {
        var item = new Item
        {
            Name = createItemDto.Name,
            Description = createItemDto.Description,
            Price = createItemDto.Price,
            CreatedDate = DateTime.Now
        };
        
        await _repository.CreateAsync(item); 

        return CreatedAtAction("GetById", new {id = item.Id}, item.AsDto());
    }
    
    // update item
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> PutAsync(Guid id, Dtos.UpdateItemDto updateItemDto)
    {
        var existingItem = await _repository.GetAsync(id);
        
        if (existingItem is null)
        {
            return NotFound();
        }
        
        existingItem.Name = updateItemDto.Name;
        existingItem.Description = updateItemDto.Description;
        existingItem.Price = updateItemDto.Price;
        
        await _repository.UpdateAsync(id, existingItem);
        
        return NoContent();
    }
    
    
    // delete item
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var existingItem = await _repository.GetAsync(id);
        
        if (existingItem is null)
        {
            return NotFound();
        }
        
        await _repository.DeleteAsync(id);
        
        return NoContent();
    }

    
}