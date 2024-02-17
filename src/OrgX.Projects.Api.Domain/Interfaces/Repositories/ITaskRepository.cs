using Entites = OrgX.Projects.Api.Domain.Entities;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Domain.Interfaces.Repositories;

public interface ITaskRepository
{
    void Add(Entites.Task entity);
    void Remove(Entites.Task entity);
    void Update(Entites.Task entity);
    IQueryable<Entites.Task>? GetAll(Expression<Func<Entites.Task, bool>>? expression = null);
    Entites.Task? GetById(Guid id);
}
