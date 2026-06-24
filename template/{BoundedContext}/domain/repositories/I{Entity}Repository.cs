using pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;

namespace pc217953u20231e795.API.{BoundedContext}.domain.repositories;

/// <summary>
/// Repository interface for {Entity} aggregates.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public interface I{Entity}Repository
{
    /// <summary>
    /// Adds a new {Entity} asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    Task<{Entity}> AddAsync({Entity} entity);
    
    /// <summary>
    /// Gets an {Entity} by its unique identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    Task<{Entity}?> GetByIdAsync(int id);

    // TODO: Add custom methods for validating uniqueness rules here.
    // Example (Hertz):
    // Task<bool> ExistsByCustomerAndVehiclesIdAsync(string customer, int vehiclesId);
    // Task<bool> ExistsByPlateAndDifferentVehiclesIdAsync(string plate, int vehiclesId);
}
