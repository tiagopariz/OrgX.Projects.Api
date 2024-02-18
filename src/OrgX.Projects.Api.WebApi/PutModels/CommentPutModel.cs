using System.Diagnostics.CodeAnalysis;

namespace OrgX.Tasks.Api.WebApi.PutModels;

[ExcludeFromCodeCoverage]
public class CommentPutModel(
    Guid id,
    string title,
    Guid taskId)
{
    public Guid Id => id;
    public string Title => title;
    public Guid TaskId => taskId;
}
