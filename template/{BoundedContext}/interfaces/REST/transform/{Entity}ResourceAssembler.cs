using pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;
using pc217953u20231e795.API.{BoundedContext}.domain.model.valueobjects;
using pc217953u20231e795.API.{BoundedContext}.interfaces.REST.resources;

namespace pc217953u20231e795.API.{BoundedContext}.interfaces.REST.transform;

/// <summary>
/// Assembler to map between {Entity} aggregates and REST resources.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public static class {Entity}ResourceAssembler
{
    /// <summary>
    /// Converts a Create{Entity}Resource to an {Entity} aggregate.
    /// </summary>
    /// <param name="resource">The creation resource.</param>
    /// <returns>The mapped {Entity}.</returns>
    public static {Entity} ToEntity(Create{Entity}Resource resource)
    {
        return new {Entity}
        {
            // TODO: Map properties from resource to entity
            // Example:
            // Customer = resource.Customer,
            // VehiclesId = resource.VehiclesId,
            // Plate = resource.Plate,
            // RequestedAt = resource.RequestedAt,
            // Amount = resource.Amount,
            // Address = new {ValueObject} 
            // {
            //     Street = resource.Street,
            //     City = resource.City,
            //     PostalCode = resource.PostalCode
            // }
        };
    }

    /// <summary>
    /// Converts an {Entity} aggregate to a {Entity}Resource.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>The mapped resource.</returns>
    public static {Entity}Resource ToResource({Entity} entity)
    {
        return new {Entity}Resource
        {
            {EntityId} = entity.{EntityId},
            // TODO: Map properties from entity to resource
            // Example:
            // Customer = entity.Customer,
            // VehiclesId = entity.VehiclesId,
            // Plate = entity.Plate,
            // RequestedAt = entity.RequestedAt,
            // Address = entity.Address
        };
    }
}
