using Microsoft.AspNetCore.Mvc;
using Play.Catalog.DTOs;

namespace Play.Catalog.Controllers;

/// <summary>
/// Controller for managing items.
/// </summary>
[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{

    /// <summary>
    /// Represents a collection of items.
    /// </summary>
    private static readonly List<Dtos.ItemDto> Items = new()
    {
        new Dtos.ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
        new Dtos.ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 7, DateTimeOffset.UtcNow),
        new Dtos.ItemDto(Guid.NewGuid(), "Bronze Sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
    };


    /// <summary>
    /// Retrieves all items.
    /// </summary>
    /// <returns>An IEnumerable of ItemDto.</returns>
    [HttpGet]
    public IEnumerable<Dtos.ItemDto> Get()
    {
        return Items;
    }


    /// <summary>
    /// Represents an item data transfer object.
    /// </summary>
    [HttpGet("{id:guid}")]
    public Dtos.ItemDto? GetById(Guid id)
    {
        var item = Items.SingleOrDefault(item => item.Id == id);
        return item;
    }


    /// <summary>
    /// Creates a new item.
    /// </summary>
    /// <param name="itemDto">The item data transfer object.</param>
    /// <returns>The newly created item.</returns>
    [HttpPost]
    public ActionResult<Dtos.ItemDto> Post(Dtos.CreateItemDto itemDto)
    {
        var item = new Dtos.ItemDto(Guid.NewGuid(), itemDto.Name, itemDto.Description, itemDto.Price, DateTimeOffset.UtcNow);
        Items.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }


    /// <summary>
    /// Updates an item.
    /// </summary>
    /// <param name="id">The item's ID.</param>
    /// <param name="itemDto">The item data transfer object.</param>
    /// <returns>A NoContentResult.</returns>
    /// <remarks>
    /// The <see cref="ProducesResponseTypeAttribute"/> is used to specify the HTTP status code returned by the action.
    /// </remarks>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put(Guid id, Dtos.UpdateItemDto itemDto)
    {
        var existingItem = Items.SingleOrDefault(item => item.Id == id);
        if (existingItem is null)
        {
            return NotFound();
        }

        var updatedItem = existingItem with
        {
            Name = itemDto.Name,
            Description = itemDto.Description,
            Price = itemDto.Price
        };

        var index = Items.FindIndex(item => item.Id == id);
        Items[index] = updatedItem;

        return NoContent();
    }
    
    

    /// <summary>
    /// Deletes an item with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the item to delete.</param>
    /// <returns>Returns a NoContent result if the item was deleted successfully, or a NotFound result if the item was not found.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(Guid id)
    {
        var existingItem = Items.SingleOrDefault(item => item.Id == id);
        if (existingItem is null)
        {
            return NotFound();
        }

        Items.Remove(existingItem);

        return NoContent();
    }

}