using pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;
using pc217953u20231e795.API.{BoundedContext}.domain.repositories;
using pc217953u20231e795.API.{BoundedContext}.domain.services;
using pc217953u20231e795.API.{BoundedContext}.interfaces.REST.resources;
using pc217953u20231e795.API.{BoundedContext}.interfaces.REST.transform;

namespace pc217953u20231e795.API.{BoundedContext}.application;

/// <summary>
/// Implementation of the command service for {Entity}.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public class {Entity}CommandService : I{Entity}CommandService
{
    private readonly I{Entity}Repository _repository;

    public {Entity}CommandService(I{Entity}Repository repository)
    {
        _repository = repository;
    }

    public async Task<{Entity}Resource> Handle(Create{Entity}Resource resource)
    {
        // TODO: Implement the business rules required by the exercise.
        // Convert the input resource into an entity to prepare for saving.
        var entity = {Entity}ResourceAssembler.ToEntity(resource);

        // Rule 1: Example duplicate check
        // if (await _repository.ExistsBySomeConditionAsync(resource.SomeProperty))
        // {
        //     throw new InvalidOperationException("Entity with this condition already exists.");
        // }

        // Rule 2: Example value validation
        // if (resource.Amount <= 0)
        // {
        //     throw new ArgumentException("Amount must be greater than zero.");
        // }
        
        // Rule 3: Example date validation
        // if (resource.RequestedAt < DateTime.UtcNow)
        // {
        //     throw new ArgumentException("Requested date cannot be in the past.");
        // }

        // Save to repository
        var savedEntity = await _repository.AddAsync(entity);

        // Return mapped resource
        return {Entity}ResourceAssembler.ToResource(savedEntity);
    }
}
