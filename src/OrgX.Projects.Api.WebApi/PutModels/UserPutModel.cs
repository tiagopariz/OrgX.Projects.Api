namespace OrgX.Projects.Api.WebApi.PutModels;

public class UserPutModel(
    Guid id,
    string username,
    string role)
{
    public Guid Id => id;
    public string Username => username;
    public string Role => role;
}
