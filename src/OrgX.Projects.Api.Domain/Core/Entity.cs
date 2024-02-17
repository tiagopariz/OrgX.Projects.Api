namespace OrgX.Projects.Api.Domain.Core;

public abstract class Entity
{
    public Guid? Id { get; private set; }

    protected Entity(
        Guid? id)
    {
        Id = id.HasValue && id.Value != Guid.Empty
            ? id.Value
            : Guid.NewGuid();
    }
}
