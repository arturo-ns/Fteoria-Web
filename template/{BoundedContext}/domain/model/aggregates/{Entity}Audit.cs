using System.ComponentModel.DataAnnotations.Schema;

namespace pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;

/// <summary>
/// Audit base class for {Entity} providing creation and modification timestamps.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public abstract partial class {Entity}Audit
{
    /// <summary>
    /// The date and time when the record was created.
    /// </summary>
    [Column("CreatedAt")] 
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// The date and time when the record was last updated.
    /// </summary>
    [Column("UpdatedAt")] 
    public DateTime UpdatedDate { get; set; }
}
