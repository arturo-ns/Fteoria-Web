using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace PC217953.U20231E795.Clerky.Platform.shared.Persistence.EFC.Extensions;

/// <summary>
/// Extension methods for applying naming conventions to EF Core model builders.
/// </summary>
public static class NamingConventionsExtension
{
    /// <summary>
    /// Applies snake_case naming conventions to all tables, columns, keys, and indexes
    /// defined in the model.
    /// </summary>
    /// <param name="builder">The <see cref="ModelBuilder"/> to apply conventions to.</param>
    public static void UserSnakeCaseNamingConventions(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName))
            {
                entity.SetTableName(ToSnakeCase(tableName));
            }

            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                if (!string.IsNullOrEmpty(columnName))
                {
                    property.SetColumnName(ToSnakeCase(columnName));
                }
            }

            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName))
                {
                    key.SetName(ToSnakeCase(keyName));
                }
            }

            foreach (var key in entity.GetForeignKeys())
            {
                var keyName = key.GetConstraintName();
                if (!string.IsNullOrEmpty(keyName))
                {
                    key.SetConstraintName(ToSnakeCase(keyName));
                }
            }

            foreach (var index in entity.GetIndexes())
            {
                var indexName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexName))
                {
                    index.SetDatabaseName(ToSnakeCase(indexName));
                }
            }
        }
    }

    private static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input)) { return input; }

        var startUnderscores = Regex.Match(input, @"^_+");
        return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
    }
}
