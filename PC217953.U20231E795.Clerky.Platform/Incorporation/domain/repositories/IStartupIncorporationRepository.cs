using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.aggregates;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.repositories;

/// <summary>
/// Repository interface for <see cref="StartupIncorporation"/> aggregates.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public interface IStartupIncorporationRepository
{
    /// <summary>
    /// Adds a new <see cref="StartupIncorporation"/> asynchronously.
    /// </summary>
    /// <param name="entity">The startup incorporation entity to add.</param>
    /// <returns>The persisted <see cref="StartupIncorporation"/> with its generated identifier.</returns>
    Task<StartupIncorporation> AddAsync(StartupIncorporation entity);

    /// <summary>
    /// Gets a <see cref="StartupIncorporation"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The identifier of the startup incorporation.</param>
    /// <returns>The <see cref="StartupIncorporation"/> if found; otherwise, <c>null</c>.</returns>
    Task<StartupIncorporation?> GetByIdAsync(int id);

    /// <summary>
    /// Determines whether a startup incorporation with the given Atlas identifier already exists.
    /// </summary>
    /// <param name="incorporationIdentifier">The GUID value of the Atlas identifier to check.</param>
    /// <returns><c>true</c> if a record with the same identifier exists; otherwise, <c>false</c>.</returns>
    Task<bool> ExistsByIncorporationIdentifierAsync(Guid incorporationIdentifier);
}
