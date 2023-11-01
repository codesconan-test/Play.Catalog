using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Play.Catalog.DTOs;
using Play.Common.Entities;

namespace Play.Catalog.Entities;

/// <summary>
/// Represents an item in the catalog.
/// </summary>
public class Item : IEntity
{
    /// <summary>
    /// The item's unique identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The item's name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The item's description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The item's price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The item's created date.
    /// </summary>
    [BsonElement("CreatedDate")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Converts the current Item object to an ItemDto object.
    /// </summary>
    /// <returns>The converted ItemDto object.</returns>
    public Dtos.ItemDto AsDto()
    {
        return new Dtos.ItemDto(Id, Name, Description, Price, CreatedDate);
    }
}