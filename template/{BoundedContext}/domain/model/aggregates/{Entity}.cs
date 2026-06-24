using pc217953u20231e795.API.{BoundedContext}.domain.model.valueobjects;

namespace pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;

/// <summary>
/// Represents the {Entity} aggregate root.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public partial class {Entity} : {Entity}Audit
{
    /// <summary>
    /// The unique identifier for the {Entity}.
    /// </summary>
    public int {EntityId} { get; set; }
    
    // TODO: Add the rest of the properties required by the exercise here.
    // Examples:
    // public string Customer { get; set; } = string.Empty;
    // public {EEnum} VehiclesId { get; set; }
    // public string Plate { get; set; } = string.Empty;
    // public DateTime RequestedAt { get; set; }
    // public double Amount { get; set; }
    
    /// <summary>
    /// The owned value object.
    /// </summary>
    public {ValueObject} {ValueObject} { get; set; } = new {ValueObject}();
}
