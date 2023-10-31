namespace Play.Catalog.Entities;

public class Item
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
    public DateTimeOffset CreatedDate { get; set; }
}