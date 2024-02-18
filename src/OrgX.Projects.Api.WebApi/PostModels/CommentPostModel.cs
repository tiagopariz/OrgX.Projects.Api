using System.Diagnostics.CodeAnalysis;

namespace OrgX.Tasks.Api.WebApi.PostModels;

[ExcludeFromCodeCoverage]
public class CommentPostModel(
    string content, 
    Guid taskId)
{
    public Guid Id => Guid.NewGuid();
    public string Content => content;
    public Guid TaskId => taskId;
}
