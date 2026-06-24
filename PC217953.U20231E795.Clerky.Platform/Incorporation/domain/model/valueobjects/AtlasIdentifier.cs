namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;

/// <summary>
/// Represents a unique Atlas identifier for a startup incorporation process.
/// The GUID value originates from another bounded context.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class AtlasIdentifier
{
    /// <summary>
    /// Gets the GUID that uniquely identifies the incorporation process.
    /// </summary>
    public Guid Identifier { get; private set; }

    /// <summary>
    /// Required by EF Core for owned entity materialization.
    /// </summary>
    private AtlasIdentifier()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AtlasIdentifier"/>.
    /// </summary>
    /// <param name="identifier">The GUID uniquely identifying the incorporation process.</param>
    public AtlasIdentifier(Guid identifier)
    {
        Identifier = identifier;
    }
}
