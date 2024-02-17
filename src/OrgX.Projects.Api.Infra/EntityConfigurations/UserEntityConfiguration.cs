using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "dbo");
        builder.HasKey(x => x.Id)
            .HasName($"IX_dbo_User_Id");

        builder.Property(x => x.Id)
            .HasColumnName($"Id");

        builder.Property(p => p.Username)
               .HasColumnName("Username")
               .IsUnicode(true)
               .HasMaxLength(30)
               .IsRequired(true);

        builder.Property(p => p.Role)
               .HasColumnName("Role")
               .IsUnicode(true)
               .HasMaxLength(30)
               .IsRequired(true);

        builder.HasIndex(h => h.Username)
               .HasDatabaseName("IX_dbo_User_Username");
    }
}
