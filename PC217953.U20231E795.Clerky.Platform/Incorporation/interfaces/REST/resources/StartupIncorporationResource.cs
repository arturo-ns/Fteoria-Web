namespace PC217953.U20231E795.Clerky.Platform.Incorporation.interfaces.REST.resources;

/// <summary>
/// Resource representing a startup incorporation as exposed by the REST API.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class StartupIncorporationResource
{
    /// <summary>
    /// Gets or sets the auto-generated unique identifier of the startup incorporation.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the Atlas identifier (GUID string) of the incorporation process.
    /// </summary>
    public string IncorporationIdentifier { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the UUID string identifying the founder.
    /// </summary>
    public string FounderId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the start date of the incorporation period as a string (yyyy-MM-dd).
    /// </summary>
    public string PeriodStartDate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the completion date of the incorporation period as a string (yyyy-MM-dd).
    /// </summary>
    public string PeriodCompletionDate { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the monetary value of the registered capital.
    /// </summary>
    public decimal RegisteredCapitalValue { get; set; }

    /// <summary>
    /// Gets or sets the currency code of the registered capital.
    /// </summary>
    public string RegisteredCapitalCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current status of the incorporation as a string name (not numeric code).
    /// </summary>
    public string Status { get; set; } = string.Empty;
}
