using OrgX.Projects.Api.Domain.Entities;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Domain.Interfaces.Repositories;

public interface IProjectRepository
{
    void Add(Project entity);
    void Remove(Project entity);
    void Update(Project entity);
    IQueryable<Project>? GetAll(Expression<Func<Project, bool>>? expression = null);
    Project? GetById(Guid id);
}
