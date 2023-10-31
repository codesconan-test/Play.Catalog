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
    private readonly IItemRepository<Item> _repository;

    public ItemsController(IItemRepository<Item> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    // endpoint: GET /items
    [HttpGet]
    public async Task<IEnumerable<Dtos.ItemDto>> GetAsync()
    {
        var items = (await _repository.GetAsync())
            .Select(item => item.AsDto());
        return items;
    }
    
    // endpoint: GET /items/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Dtos.ItemDto>> GetByIdAsync(Guid id)
    {
        var item = await _repository.GetAsync(id);
        if(item == null)
        {
            return NotFound();
        }
        return item.AsDto();
    }
    
    // endpoint: POST /items
    [HttpPost]
    public async Task<ActionResult<Dtos.ItemDto>> PostAsync(Dtos.CreateItemDto createItemDto)
    {
        var item = new Item
        {
            Name = createItemDto.Name,
            Description = createItemDto.Description,
            Price = createItemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow.Date
        };
        
        await _repository.CreateAsync(item);
        
        return CreatedAtAction("GetById", new {id = item.Id}, item);
    }
    
    
}