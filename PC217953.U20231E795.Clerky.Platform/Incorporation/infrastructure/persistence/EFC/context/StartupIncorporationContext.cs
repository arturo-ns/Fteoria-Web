using Microsoft.EntityFrameworkCore;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.aggregates;
using PC217953.U20231E795.Clerky.Platform.Incorporation.domain.model.valueobjects;
using PC217953.U20231E795.Clerky.Platform.shared.Persistence.EFC.Extensions;

namespace PC217953.U20231E795.Clerky.Platform.Incorporation.infrastructure.persistence.EFC.context;

/// <summary>
/// Database context for the Incorporation bounded context.
/// Configures entity mappings and applies snake_case naming conventions.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class StartupIncorporationContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="StartupIncorporationContext"/>.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public StartupIncorporationContext(DbContextOptions<StartupIncorporationContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the DbSet for startup incorporations.
    /// </summary>
    public DbSet<StartupIncorporation> StartupIncorporations { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<StartupIncorporation>().ToTable("StartupIncorporations");

        builder.Entity<StartupIncorporation>().HasKey(e => e.Id);
        builder.Entity<StartupIncorporation>()
            .Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<StartupIncorporation>()
            .Property(e => e.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Entity<StartupIncorporation>()
            .Property(e => e.Notes)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Entity<StartupIncorporation>().OwnsOne(e => e.IncorporationIdentifier, a =>
        {
            a.Property(p => p.Identifier)
                .HasColumnName("IncorporationIdentifier")
                .IsRequired();
        });

        builder.Entity<StartupIncorporation>().OwnsOne(e => e.FounderId, a =>
        {
            a.Property(p => p.Value)
                .HasColumnName("FounderId")
                .IsRequired();
        });

        builder.Entity<StartupIncorporation>().OwnsOne(e => e.Period, a =>
        {
            a.Property(p => p.StartDate)
                .HasColumnName("PeriodStartDate")
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v))
                .HasColumnType("date")
                .IsRequired();

            a.Property(p => p.CompletionDate)
                .HasColumnName("PeriodCompletionDate")
                .HasConversion(
                    v => v.ToDateTime(TimeOnly.MinValue),
                    v => DateOnly.FromDateTime(v))
                .HasColumnType("date")
                .IsRequired();
        });

        builder.Entity<StartupIncorporation>().OwnsOne(e => e.RegisteredCapital, a =>
        {
            a.Property(p => p.Value)
                .HasColumnName("RegisteredCapitalValue")
                .IsRequired();

            a.Property(p => p.Currency)
                .HasColumnName("RegisteredCapitalCurrency")
                .IsRequired()
                .HasMaxLength(10);
        });

        builder.UserSnakeCaseNamingConventions();
    }
}
