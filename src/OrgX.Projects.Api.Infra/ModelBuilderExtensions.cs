using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Infra;

[ExcludeFromCodeCoverage]
public static class ModelBuilderExtensions
{
    public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
            if (entity.FindProperty($"Id") != null)
                entity.SetTableName(entity.DisplayName());
    }

    public static void DeleteCascadeBehaviorToRestrict(this ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys()))
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
    }

    public static void SetPrimaryKey(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
            if (entity.FindProperty($"Id") != null)
                entity.GetProperty($"Id").IsKey();
    }

    public static void SetMaxLength(this ModelBuilder modelBuilder, int maxLength = 100)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                    .SelectMany(x => x.GetProperties())
                                    .Where(x => x.ClrType == typeof(string)))
            if (property.GetMaxLength() == null)
                property.SetMaxLength(maxLength);
    }

    public static void SetVarchar(this ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                    .SelectMany(x => x.GetProperties())
                                    .Where(x => x.ClrType == typeof(string)))
            if (property.IsUnicode() == null)
                property.SetIsUnicode(false);
    }
}
