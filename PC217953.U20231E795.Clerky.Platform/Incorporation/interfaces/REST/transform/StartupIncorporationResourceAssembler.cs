using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.aggregates;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;
using PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.resources;
using PC217953.U20231E795.Clerky.Platform.shared.Domain.Model.ValueObjects;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.transform;

/// <summary>
/// Assembler responsible for mapping between <see cref="StartupIncorporation"/> aggregates
/// and their corresponding REST resources.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public static class StartupIncorporationResourceAssembler
{
    /// <summary>
    /// Converts a <see cref="CreateStartupIncorporationResource"/> to a <see cref="StartupIncorporation"/> aggregate.
    /// Value object constructors are called here, triggering domain validation.
    /// </summary>
    /// <param name="resource">The creation resource with flat primitive fields.</param>
    /// <returns>A new <see cref="StartupIncorporation"/> entity ready for persistence.</returns>
    public static StartupIncorporation ToEntity(CreateStartupIncorporationResource resource)
    {
        return new StartupIncorporation
        {
            IncorporationIdentifier = new AtlasIdentifier(resource.IncorporationIdentifier),
            FounderId = new FounderId(resource.FounderId),
            Period = new IncorporationPeriod(resource.PeriodStartDate, resource.PeriodCompletionDate),
            RegisteredCapital = new RegisteredCapital(resource.RegisteredCapitalValue, resource.RegisteredCapitalCurrency),
            Status = resource.Status,
            Notes = resource.Notes
        };
    }

    /// <summary>
    /// Converts a <see cref="StartupIncorporation"/> aggregate to a <see cref="StartupIncorporationResource"/>.
    /// </summary>
    /// <param name="entity">The persisted startup incorporation entity.</param>
    /// <returns>A <see cref="StartupIncorporationResource"/> ready to be returned by the API.</returns>
    public static StartupIncorporationResource ToResource(StartupIncorporation entity)
    {
        return new StartupIncorporationResource
        {
            Id = entity.Id,
            IncorporationIdentifier = entity.IncorporationIdentifier.Identifier.ToString(),
            FounderId = entity.FounderId.Value.ToString(),
            PeriodStartDate = entity.Period.StartDate.ToString("yyyy-MM-dd"),
            PeriodCompletionDate = entity.Period.CompletionDate.ToString("yyyy-MM-dd"),
            RegisteredCapitalValue = entity.RegisteredCapital.Value,
            RegisteredCapitalCurrency = entity.RegisteredCapital.Currency,
            Status = entity.Status.ToString()
        };
    }
}
