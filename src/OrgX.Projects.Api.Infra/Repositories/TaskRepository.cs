using Microsoft.EntityFrameworkCore;
using Entities = OrgX.Projects.Api.Domain.Entities;
using System.Linq.Expressions;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using OrgX.Projects.Api.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Infra.Repositories;

[ExcludeFromCodeCoverage]
public class TaskRepository : ITaskRepository
{
    private readonly DbSet<Entities.Task> _dbSet;
    private readonly IHistoryRepository _historyRepository;
    private readonly ProjectsDbContext _context;
    private const string UserId = "2bd26aa6-5344-4e51-b4b8-144bfb631f3f";

    public TaskRepository(IConfiguration configuration,
                          IHistoryRepository historyRepository)
    {
        _context = new ProjectsDbContext(configuration);
        _dbSet = _context.Set<Entities.Task>();
        _historyRepository = historyRepository;
    }

    public virtual void Add(Entities.Task entity)
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

    public virtual void Remove(Entities.Task entity)
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

    public virtual void Update(Entities.Task entity)
    {
        try
        {
            var dbEntity = _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == entity.Id);
            if (dbEntity != null)
            { 
                var entityToSave = new Entities.Task(
                    entity.Id,
                    entity.Title,
                    entity.Detail,
                    entity.Status,
                    dbEntity.Priority,
                    entity.EndDate,
                    entity.ProjectId);

                if (_context != null)
                    _context.Entry(entityToSave).State = EntityState.Modified;
                _context.SaveChanges();
                SaveHistory(entity, "UPDATE");
            }
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IQueryable<Entities.Task>? GetAll(Expression<Func<Entities.Task, bool>>? expression = null)
    {
        try
        {
            var query = _dbSet.AsQueryable().Include("Project").Select(
                    x => new Entities.Task(
                        x.Id,
                        x.Title,
                        x.Detail,
                        x.Status,
                        x.Priority,
                        x.EndDate,
                        x.ProjectId,
                        new Project(
                            x.Project.Id,
                            x.Project.Title,
                            x.Project.UserId,
                            null,
                            null),
                        null));

            return expression == null 
                ? query
                : query.Where(expression);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public Entities.Task? GetById(Guid id)
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

    private void SaveHistory(Entities.Task entity, string operation)
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
            "Detail",
            operation,
            (Guid)entity.Id,
            entity.Detail,
            Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "Status",
            operation,
            (Guid)entity.Id,
            entity.Status.ToString(),
            Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "Priority",
            operation,
            (Guid)entity.Id,
            entity.Priority.ToString(),
            Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "EndDate",
            operation,
            (Guid)entity.Id,
            entity.EndDate.ToString(),
            Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "ProjectId",
            operation,
            (Guid)entity.Id,
            entity.ProjectId.ToString(),
            Guid.Parse(UserId));
    }
}
