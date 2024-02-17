using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.Seeds;

public static partial class Seed
{
    public static void UserSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                Username = "tiagopariz",
                Role = "User"
            },
            new
            {
                Id = Guid.Parse("4ee007a2-e556-46cb-941d-0472aec0fe9b"),
                Username = "vangogh",
                Role = "Manager"
            });
    }
}
