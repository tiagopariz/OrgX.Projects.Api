using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.EntityConfigurations;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comment", "dbo");
        builder.HasKey(x => x.Id)
            .HasName($"IX_dbo_Comment_Id");

        builder.Property(x => x.Id)
            .HasColumnName($"Id");

        builder.Property(p => p.Content)
               .HasColumnName("Content")
               .IsUnicode(true)
               .HasMaxLength(1024)
               .IsRequired(true);

        builder.Property(x => x.TaskId)
               .HasColumnName("TaskId")
               .IsRequired(true);

        builder.HasOne(x => x.Task)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.TaskId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_dbo_Comment_TaskId_dbo_Task_Id");
    }
}
