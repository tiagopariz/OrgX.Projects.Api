using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.DeleteModels;

[ExcludeFromCodeCoverage]
public class ProjectDeleteModel(Guid id, string title, Guid userId)
{
    public Guid Id => id;
    public string Title => title;
    public Guid UserId => userId;
}
