using Microsoft.EntityFrameworkCore;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.aggregates;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.repositories;
using PC217953.U20231E795.Clerky.Platform.Incorporation.infrastructure.persistence.EFC.context;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.infrastructure.persistence.EFC.repositories;

/// <summary>
/// EF Core implementation of <see cref="IStartupIncorporationRepository"/>.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class StartupIncorporationRepository : IStartupIncorporationRepository
{
    private readonly StartupIncorporationContext _context;

    /// <summary>
    /// Initializes a new instance of <see cref="StartupIncorporationRepository"/>.
    /// </summary>
    /// <param name="context">The EF Core database context.</param>
    public StartupIncorporationRepository(StartupIncorporationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new <see cref="StartupIncorporation"/> to the database.
    /// Sets audit timestamps before persisting.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The persisted entity with its generated identifier.</returns>
    public async Task<StartupIncorporation> AddAsync(StartupIncorporation entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.UpdatedDate = DateTime.UtcNow;

        await _context.StartupIncorporations.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Retrieves a <see cref="StartupIncorporation"/> by its primary key.
    /// </summary>
    /// <param name="id">The primary key identifier.</param>
    /// <returns>The found entity, or <c>null</c> if not found.</returns>
    public async Task<StartupIncorporation?> GetByIdAsync(int id)
    {
        return await _context.StartupIncorporations
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    /// <summary>
    /// Checks whether a startup incorporation with the given Atlas identifier already exists.
    /// </summary>
    /// <param name="incorporationIdentifier">The GUID value of the Atlas identifier to check.</param>
    /// <returns><c>true</c> if a matching record exists; otherwise, <c>false</c>.</returns>
    public async Task<bool> ExistsByIncorporationIdentifierAsync(Guid incorporationIdentifier)
    {
        return await _context.StartupIncorporations
            .AnyAsync(e => e.IncorporationIdentifier.Identifier == incorporationIdentifier);
    }
}
