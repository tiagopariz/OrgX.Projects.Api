using Microsoft.EntityFrameworkCore;
using Entities = OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.Seeds;

public static partial class Seed
{
    public static void TaskSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Task>().HasData(
            new
            {
                Id = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Title = "Task 1 - Project 1",
                Detail = "Task 1 of Project 1",
                Status = (short) 0,
                Priority = (short) 0,
                ProjectId = Guid.Parse("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d")
            });
    }
}
