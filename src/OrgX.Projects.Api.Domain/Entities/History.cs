using OrgX.Projects.Api.Domain.Core;

namespace OrgX.Projects.Api.Domain.Entities;

public class History(
    Guid? id,
    string entity,
    string field,
    Guid primaryKeyId,
    string operation,
    string? newValue,
    Guid userId,
    DateTime registerDate,
    User? user = null)
    : Entity(id)
{
    public string Entity => entity;
    public string Field => field;
    public Guid PrimaryKeyId => primaryKeyId;
    public string Operation => operation;
    public string? NewValue => newValue;
    public Guid UserId => userId;
    public DateTime RegisterDate => registerDate;
    public User? User { get; private set; } = user;

    public History(
        Guid? id,
        string entity,
        string field,
        Guid primaryKeyId,
        string operation,
        string? newValue,
        Guid userId,
        DateTime registerDate)
        : this(
              id,
              entity,
              field,
              primaryKeyId,
              operation,
              newValue,
              userId,
              registerDate,
              null) { }
}
