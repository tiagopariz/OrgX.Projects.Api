using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.PutModels;

[ExcludeFromCodeCoverage]
public class UserPutModel(
    Guid id,
    string username,
    string role)
{
    public Guid Id => id;
    public string Username => username;
    public string Role => role;
}
