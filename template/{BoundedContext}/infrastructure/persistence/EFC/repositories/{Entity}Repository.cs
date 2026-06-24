using Microsoft.EntityFrameworkCore;
using pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;
using pc217953u20231e795.API.{BoundedContext}.domain.repositories;
using pc217953u20231e795.API.{BoundedContext}.infrastructure.persistence.EFC.context;

namespace pc217953u20231e795.API.{BoundedContext}.infrastructure.persistence.EFC.repositories;

/// <summary>
/// Implementation of the repository for {Entity}.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public class {Entity}Repository : I{Entity}Repository
{
    private readonly {Entity}Context _context;

    public {Entity}Repository({Entity}Context context)
    {
        _context = context;
    }

    public async Task<{Entity}> AddAsync({Entity} entity)
    {
        // Set creation/update timestamps
        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdatedDate = DateTime.UtcNow;

        await _context.{Entities}.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<{Entity}?> GetByIdAsync(int id)
    {
        return await _context.{Entities}.FirstOrDefaultAsync(e => e.{EntityId} == id);
    }

    // TODO: Implement custom validation methods here
    // Example:
    // public async Task<bool> ExistsByCustomerAndVehiclesIdAsync(string customer, int vehiclesId)
    // {
    //     return await _context.{Entities}.AnyAsync(e => e.Customer == customer && (int)e.VehiclesId == vehiclesId);
    // }
}
