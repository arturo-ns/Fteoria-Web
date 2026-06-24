using System.ComponentModel.DataAnnotations.Schema;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.aggregates;

/// <summary>
/// Audit base class for <see cref="StartupIncorporation"/> providing creation and last-update timestamps.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public abstract partial class StartupIncorporationAudit
{
    /// <summary>
    /// Gets or sets the date and time when the record was created.
    /// </summary>
    [Column("CreatedAt")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the record was last updated.
    /// </summary>
    [Column("UpdatedAt")]
    public DateTime UpdatedDate { get; set; }
}
