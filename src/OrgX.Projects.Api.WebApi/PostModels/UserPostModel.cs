namespace OrgX.Projects.Api.WebApi.PostModels;

public class UserPostModel(
    string username,
    string role)
{
    public Guid Id => Guid.NewGuid();
    public string Username => username;
    public string Role => role;
}
