using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Infra.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Project", "dbo");
        builder.HasKey(x => x.Id)
            .HasName($"IX_dbo_Project_Id");

        builder.Property(x => x.Id)
            .HasColumnName($"Id");

        builder.Property(p => p.Title)
               .HasColumnName("Title")
               .IsUnicode(true)
               .HasMaxLength(200)
               .IsRequired(true);

        builder.Property(x => x.UserId)
               .HasColumnName("UserId")
               .IsRequired(true);

        builder.HasOne(x => x.User)
               .WithMany(x => x.Projects)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_dbo_Project_UserId_dbo_User_Id");

        builder.HasIndex(h => h.Title)
               .HasDatabaseName("IX_dbo_Project_Title");
    }
}
