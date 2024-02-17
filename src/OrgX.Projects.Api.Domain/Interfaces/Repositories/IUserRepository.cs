using OrgX.Projects.Api.Domain.Entities;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    IQueryable<User>? GetAll(Expression<Func<User, bool>>? expression = null);
    User? GetById(Guid id);
}
