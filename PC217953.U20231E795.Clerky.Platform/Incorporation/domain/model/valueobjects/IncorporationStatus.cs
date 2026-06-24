namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;

/// <summary>
/// Represents the current status of a startup incorporation process.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public enum IncorporationStatus
{
    /// <summary>
    /// The incorporation is in draft state. This is the default status.
    /// </summary>
    Draft = 0,

    /// <summary>
    /// The incorporation process is currently in progress.
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// The incorporation has been completed successfully.
    /// </summary>
    Completed = 2,

    /// <summary>
    /// The incorporation has been cancelled.
    /// </summary>
    Cancelled = 3
}
