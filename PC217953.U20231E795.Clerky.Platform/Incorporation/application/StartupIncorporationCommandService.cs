using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.repositories;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.services;
using PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.resources;
using PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.transform;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.application;

/// <summary>
/// Implementation of the command service for startup incorporation operations.
/// Handles business rule validation and delegates persistence to the repository.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class StartupIncorporationCommandService : IStartupIncorporationCommandService
{
    private readonly IStartupIncorporationRepository _repository;

    /// <summary>
    /// Initializes a new instance of <see cref="StartupIncorporationCommandService"/>.
    /// </summary>
    /// <param name="repository">The repository used to persist startup incorporations.</param>
    public StartupIncorporationCommandService(IStartupIncorporationRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Handles the creation of a new startup incorporation.
    /// Validates that no duplicate incorporation identifier exists, converts the resource to
    /// an entity (which triggers value object validation), persists it, and returns the result.
    /// </summary>
    /// <param name="resource">The resource containing the input data for the new incorporation.</param>
    /// <returns>The created <see cref="StartupIncorporationResource"/> including the generated identifier.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when a startup incorporation with the same <c>IncorporationIdentifier</c> already exists.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the provided data violates value object constraints (e.g., invalid period dates or capital values).
    /// </exception>
    public async Task<StartupIncorporationResource> Handle(CreateStartupIncorporationResource resource)
    {
        if (await _repository.ExistsByIncorporationIdentifierAsync(resource.IncorporationIdentifier))
            throw new InvalidOperationException(
                "A startup incorporation with this incorporation identifier already exists.");

        var entity = StartupIncorporationResourceAssembler.ToEntity(resource);

        var savedEntity = await _repository.AddAsync(entity);

        return StartupIncorporationResourceAssembler.ToResource(savedEntity);
    }
}
