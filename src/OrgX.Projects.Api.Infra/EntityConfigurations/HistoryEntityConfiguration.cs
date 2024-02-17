using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.EntityConfigurations;

public class HistoryEntityConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.ToTable("History", "dbo");
        builder.HasKey(x => x.Id)
            .HasName($"IX_dbo_History_Id");

        builder.Property(x => x.Id)
            .HasColumnName($"Id");

        builder.Property(p => p.Entity)
               .HasColumnName("Entity")
               .IsUnicode(true)
               .HasMaxLength(50)
               .IsRequired(true);

        builder.Property(p => p.Field)
               .HasColumnName("Field")
               .IsUnicode(true)
               .HasMaxLength(50)
               .IsRequired(true);

        builder.Property(x => x.PrimaryKeyId)
               .HasColumnName("PrimaryKeyId")
               .IsRequired(true);

        builder.Property(p => p.Operation)
               .HasColumnName("Operation")
               .IsUnicode(true)
               .HasMaxLength(10)
               .IsRequired(true);

        builder.Property(p => p.NewValue)
               .HasColumnName("NewValue")
               .IsUnicode(true)
               .IsRequired(true);

        builder.Property(p => p.RegisterDate)
               .HasColumnType($"datetime2")
               .IsRequired(true);

        builder.Property(x => x.UserId)
               .HasColumnName("UserId")
               .IsRequired(true);

        builder.HasOne(x => x.User)
               .WithMany(x => x.Histories)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("FK_dbo_History_UserId_dbo_User_Id");
    }
}
