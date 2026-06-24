namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;

/// <summary>
/// Represents the unique identifier of the founder of a startup incorporation.
/// The UUID value originates from another bounded context.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class FounderId
{
    /// <summary>
    /// Gets the UUID that identifies the founder.
    /// </summary>
    public Guid Value { get; private set; }

    /// <summary>
    /// Required by EF Core for owned entity materialization.
    /// </summary>
    private FounderId()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FounderId"/>.
    /// </summary>
    /// <param name="value">The UUID identifying the founder.</param>
    public FounderId(Guid value)
    {
        Value = value;
    }
}
