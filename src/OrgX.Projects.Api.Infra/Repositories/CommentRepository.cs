using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Infra.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly DbSet<Comment> _dbSet;
    private readonly IHistoryRepository _historyRepository;
    private readonly ProjectsDbContext _context;
    private const string UserId = "2bd26aa6-5344-4e51-b4b8-144bfb631f3f";

    public CommentRepository(
        IConfiguration configuration,
        IHistoryRepository historyRepository)
    {
        _context = new ProjectsDbContext(configuration);
        _dbSet = _context.Set<Comment>();
        _historyRepository = historyRepository;
    }

    public virtual void Add(Comment entity)
    {
        try
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            SaveHistory(entity, "INSERT");
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public virtual void Remove(Comment entity)
    {
        try
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            SaveHistory(entity, "DELETE");
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public virtual void Update(Comment entity)
    {
        try
        {
            if (_context != null)
                _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            SaveHistory(entity, "UPDATE");
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IQueryable<Comment>? GetAll(Expression<Func<Comment, bool>>? expression = null)
    {
        try
        {
            return expression == null ? _dbSet.AsQueryable() : _dbSet.Where(expression);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public Comment? GetById(Guid id)
    {
        try
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    private void SaveHistory(Comment entity, string operation)
    {
        if (entity == null || entity.Id != Guid.Empty || entity.Id != null)
            return;

        if (operation == "INSERT")
            _historyRepository.NewHistory(
                entity.GetType().Name,
                "Id",
                operation,
                (Guid)entity.Id,
                entity.Id.ToString(),
                Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "Content",
            operation,
            (Guid)entity.Id,
            entity.Content,
            Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "TaskId",
            operation,
            (Guid)entity.Id,
            entity.TaskId.ToString(),
            Guid.Parse(UserId));
    }
}
