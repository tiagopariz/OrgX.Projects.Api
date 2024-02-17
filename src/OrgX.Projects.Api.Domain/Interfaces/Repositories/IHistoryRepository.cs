using OrgX.Projects.Api.Domain.Entities;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Domain.Interfaces.Repositories;

public interface IHistoryRepository
{
    void Add(History entity);
    void Remove(History entity);
    void Update(History entity);
    IQueryable<History>? GetAll(Expression<Func<History, bool>>? expression = null);
    History? GetById(Guid id);
    void NewHistory(string entity,
        string field,
        string operation,
        Guid primaryKeyId,
        string? newValue,
        Guid userId);
}
