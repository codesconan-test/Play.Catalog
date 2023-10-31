using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.DTOs;

public class Dtos
{
    /// <summary>
    /// Represents the data transfer object for an item.
    /// </summary>
    public record ItemDto(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);

    /// <summary>
    /// Represents the data transfer object for creating an item.
    /// </summary>
    public record CreateItemDto([Required] string Name, string Description, [Range(0,1000)]  decimal Price);

    /// <summary>
    /// Represents the data transfer object for updating an item.
    /// </summary>
    public record UpdateItemDto([Required] string Name, string Description, [Range(0,1000)] decimal Price);
}