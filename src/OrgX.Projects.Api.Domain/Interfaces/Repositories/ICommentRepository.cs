using OrgX.Projects.Api.Domain.Entities;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Domain.Interfaces.Repositories;

public interface ICommentRepository
{
    void Add(Comment entity);
    void Remove(Comment entity);
    void Update(Comment entity);
    IQueryable<Comment>? GetAll(Expression<Func<Comment, bool>>? expression = null);
    Comment? GetById(Guid id);
}
