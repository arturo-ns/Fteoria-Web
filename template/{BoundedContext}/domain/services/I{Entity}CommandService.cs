using pc217953u20231e795.API.{BoundedContext}.interfaces.REST.resources;

namespace pc217953u20231e795.API.{BoundedContext}.domain.services;

/// <summary>
/// Command service interface for {Entity}.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public interface I{Entity}CommandService
{
    /// <summary>
    /// Handles the creation of a new {Entity}.
    /// </summary>
    /// <param name="resource">The creation resource containing the input data.</param>
    /// <returns>The created {Entity} resource.</returns>
    Task<{Entity}Resource> Handle(Create{Entity}Resource resource);
}
