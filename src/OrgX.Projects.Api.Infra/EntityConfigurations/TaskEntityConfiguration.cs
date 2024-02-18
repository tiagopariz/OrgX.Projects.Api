using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities = OrgX.Projects.Api.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Infra.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class TaskEntityConfiguration : IEntityTypeConfiguration<Entities.Task>
{
    public void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        builder.ToTable("Task", "dbo");
        builder.HasKey(x => x.Id)
            .HasName($"IX_dbo_Task_Id");

        builder.Property(x => x.Id)
            .HasColumnName($"Id");

        builder.Property(p => p.Title)
               .HasColumnName("Title")
               .IsUnicode(true)
               .HasMaxLength(30)
               .IsRequired(true);

        builder.Property(p => p.Detail)
               .HasColumnName("Detail")
               .IsUnicode(true)
               .HasMaxLength(1024)
               .IsRequired(true);

        builder.Property(p => p.Status)
               .HasColumnName("Status")
               .IsRequired(true);

        builder.Property(p => p.Priority)
               .HasColumnName("Priority")
               .IsRequired(true);

        builder.Property(p => p.EndDate)
               .IsRequired(false);

        builder.Property(x => x.ProjectId)
               .HasColumnName("ProjectId")
               .IsRequired(false);

        builder.HasOne(x => x.Project)
               .WithMany(x => x.Tasks)
               .HasForeignKey(x => x.ProjectId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_dbo_Task_ProjectId_dbo_Project_Id");

        builder.HasIndex(h => h.Title)
               .HasDatabaseName("IX_dbo_Task_Title");
    }
}
