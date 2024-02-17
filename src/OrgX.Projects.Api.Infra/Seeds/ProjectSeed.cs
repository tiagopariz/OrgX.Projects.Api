using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.Seeds;

public static partial class Seed
{
    public static void ProjectSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(
            new
            {
                Id = Guid.Parse("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"),
                Title = "Project 1",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f")
            });
    }
}
