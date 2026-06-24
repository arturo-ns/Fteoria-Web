using pc217953u20231e795.API.{BoundedContext}.domain.model.valueobjects;

namespace pc217953u20231e795.API.{BoundedContext}.interfaces.REST.resources;

/// <summary>
/// Resource representing an {Entity} exposed by the API.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public class {Entity}Resource
{
    /// <summary>
    /// The unique identifier.
    /// </summary>
    public int {EntityId} { get; set; }

    // TODO: Add properties to be exposed in the response.
    // NOTE: Only include fields allowed by the exercise. Do not include audit fields.
    // Example:
    // public string Customer { get; set; } = string.Empty;
    // public {EEnum} VehiclesId { get; set; }
    // public string Plate { get; set; } = string.Empty;
    // public DateTime RequestedAt { get; set; }
    // public {ValueObject} Address { get; set; } = new {ValueObject}();
}
