using PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.resources;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.services;

/// <summary>
/// Command service interface for <c>StartupIncorporation</c> operations.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public interface IStartupIncorporationCommandService
{
    /// <summary>
    /// Handles the creation of a new startup incorporation.
    /// </summary>
    /// <param name="resource">The resource containing the input data for the new incorporation.</param>
    /// <returns>The created <see cref="StartupIncorporationResource"/> including the generated identifier.</returns>
    Task<StartupIncorporationResource> Handle(CreateStartupIncorporationResource resource);
}
