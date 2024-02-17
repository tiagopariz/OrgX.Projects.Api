using Microsoft.EntityFrameworkCore;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.Seeds;

public static partial class Seed
{
    public static void HistorySeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<History>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Project",
                Field = "Id",
                PrimaryKeyId = Guid.Parse("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"),
                Operation = "INSERT",
                NewValue = "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Project",
                Field = "Title",
                PrimaryKeyId = Guid.Parse("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"),
                Operation = "INSERT",
                NewValue = "Project 1",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Project",
                Field = "UserId",
                PrimaryKeyId = Guid.Parse("beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"),
                Operation = "INSERT",
                NewValue = "2bd26aa6-5344-4e51-b4b8-144bfb631f3f",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Task",
                Field = "Id",
                PrimaryKeyId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Operation = "INSERT",
                NewValue = "66e7562d-3719-4da6-bdcb-95c2e38c80a1",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Task",
                Field = "Title",
                PrimaryKeyId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Operation = "INSERT",
                NewValue = "Task 1 - Project 1",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Task",
                Field = "Detail",
                PrimaryKeyId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Operation = "INSERT",
                NewValue = "Task 1 of Project 1",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Task",
                Field = "Status",
                PrimaryKeyId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Operation = "INSERT",
                NewValue = "0",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Task",
                Field = "Priority",
                PrimaryKeyId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Operation = "INSERT",
                NewValue = "0",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "Task",
                Field = "ProjectId",
                PrimaryKeyId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1"),
                Operation = "INSERT",
                NewValue = "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "User",
                Field = "Id",
                PrimaryKeyId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                Operation = "INSERT",
                NewValue = "2bd26aa6-5344-4e51-b4b8-144bfb631f3f",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "User",
                Field = "Username",
                PrimaryKeyId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                Operation = "INSERT",
                NewValue = "tiagopariz",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Entity = "User",
                Field = "Role",
                PrimaryKeyId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                Operation = "INSERT",
                NewValue = "Manager",
                UserId = Guid.Parse("2bd26aa6-5344-4e51-b4b8-144bfb631f3f"),
                RegisterDate = DateTime.Now
            });
    }
}
