using Microsoft.EntityFrameworkCore;
using pc217953u20231e795.API.{BoundedContext}.domain.model.aggregates;
using pc217953u20231e795.API.shared.Persistence.EFC.Extensions;

namespace pc217953u20231e795.API.{BoundedContext}.infrastructure.persistence.EFC.context;

/// <summary>
/// Database context for the {BoundedContext} bounded context.
/// </summary>
/// <remarks>Author: {AuthorName}</remarks>
public class {Entity}Context : DbContext
{
    public {Entity}Context(DbContextOptions<{Entity}Context> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the {Entities} db set.
    /// </summary>
    public DbSet<{Entity}> {Entities} { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Map to table name (plural, snake_case)
        builder.Entity<{Entity}>().ToTable("{Entities}".ToLower());

        // Configure Primary Key
        builder.Entity<{Entity}>().HasKey(e => e.{EntityId});
        builder.Entity<{Entity}>().Property(e => e.{EntityId}).IsRequired().ValueGeneratedOnAdd();

        // TODO: Configure the rest of the properties
        // Example:
        // builder.Entity<{Entity}>().Property(e => e.Customer).IsRequired().HasMaxLength(90);
        // builder.Entity<{Entity}>().Property(e => e.Amount).IsRequired();

        // Configure enum mapping
        // Example:
        // builder.Entity<{Entity}>().Property(e => e.VehiclesId).HasConversion<int>().IsRequired();

        // Configure Owned Type
        builder.Entity<{Entity}>().OwnsOne(e => e.{ValueObject}, a =>
        {
            // TODO: Configure properties of the owned type
            // Example:
            // a.Property(p => p.Street).HasColumnName("Street").IsRequired().HasMaxLength(40);
            // a.Property(p => p.City).HasColumnName("City").IsRequired().HasMaxLength(40);
        });

        // Apply snake case naming conventions (MUST be at the end)
        builder.UserSnakeCaseNamingConventions();
    }
}
