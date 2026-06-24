using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.resources;

/// <summary>
/// Resource containing the flat input data required to create a new startup incorporation.
/// Value object attributes are expressed as primitive types.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class CreateStartupIncorporationResource
{
    /// <summary>
    /// Gets or sets the GUID that uniquely identifies the incorporation process (AtlasIdentifier).
    /// </summary>
    public Guid IncorporationIdentifier { get; set; }

    /// <summary>
    /// Gets or sets the UUID identifying the founder (FounderId).
    /// </summary>
    public Guid FounderId { get; set; }

    /// <summary>
    /// Gets or sets the start date of the incorporation period.
    /// </summary>
    public DateOnly PeriodStartDate { get; set; }

    /// <summary>
    /// Gets or sets the completion date of the incorporation period.
    /// Must be greater than <see cref="PeriodStartDate"/>.
    /// </summary>
    public DateOnly PeriodCompletionDate { get; set; }

    /// <summary>
    /// Gets or sets the monetary value of the registered capital. Must be greater than or equal to zero.
    /// </summary>
    public decimal RegisteredCapitalValue { get; set; }

    /// <summary>
    /// Gets or sets the currency code of the registered capital (e.g., "USD"). Must not be null or blank.
    /// </summary>
    public string RegisteredCapitalCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the incorporation status. Defaults to <see cref="IncorporationStatus.Draft"/> if not specified.
    /// </summary>
    public IncorporationStatus Status { get; set; } = IncorporationStatus.Draft;

    /// <summary>
    /// Gets or sets optional notes for this incorporation.
    /// </summary>
    public string? Notes { get; set; }
}
