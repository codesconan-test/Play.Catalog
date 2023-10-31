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
    public record CreateItemDto(string Name, string Description, decimal Price);

    /// <summary>
    /// Represents the data transfer object for updating an item.
    /// </summary>
    public record UpdateItemDto(string Name, string Description, decimal Price);
}