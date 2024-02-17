using Microsoft.EntityFrameworkCore;
using Entities = OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.Seeds;

public static partial class Seed
{
    public static void CommentSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Comment>().HasData(
            new
            {
                Id = Guid.Parse("c56b72d6-4716-45eb-bd5a-57b89d6dcff0"),
                Content = "Comment 1 - Task 1",
                TaskId = Guid.Parse("66e7562d-3719-4da6-bdcb-95c2e38c80a1")
            });
    }
}
