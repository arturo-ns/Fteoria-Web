using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;
using PC217953.U20231E795.Clerky.Platform.shared.Domain.Model.ValueObjects;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.aggregates;

/// <summary>
/// Represents the StartupIncorporation aggregate root, which models the process of incorporating
/// a startup within the Stripe Atlas ecosystem.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public partial class StartupIncorporation : StartupIncorporationAudit
{
    /// <summary>
    /// Gets or sets the unique identifier for the startup incorporation. Auto-generated on persistence.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the Atlas identifier that uniquely identifies this incorporation process.
    /// </summary>
    public AtlasIdentifier IncorporationIdentifier { get; set; } = new AtlasIdentifier(Guid.Empty);

    /// <summary>
    /// Gets or sets the identifier of the founder associated with this incorporation.
    /// </summary>
    public FounderId FounderId { get; set; } = new FounderId(Guid.Empty);

    /// <summary>
    /// Gets or sets the period during which the incorporation takes place.
    /// </summary>
    public IncorporationPeriod Period { get; set; } = new IncorporationPeriod(
        DateOnly.FromDateTime(DateTime.UtcNow),
        DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)));

    /// <summary>
    /// Gets or sets the registered capital for this incorporation.
    /// </summary>
    public RegisteredCapital RegisteredCapital { get; set; } = new RegisteredCapital(0, "USD");

    /// <summary>
    /// Gets or sets the current status of the incorporation. Defaults to <see cref="IncorporationStatus.Draft"/>.
    /// </summary>
    public IncorporationStatus Status { get; set; } = IncorporationStatus.Draft;

    /// <summary>
    /// Gets or sets optional notes associated with this incorporation.
    /// </summary>
    public string? Notes { get; set; }
}
