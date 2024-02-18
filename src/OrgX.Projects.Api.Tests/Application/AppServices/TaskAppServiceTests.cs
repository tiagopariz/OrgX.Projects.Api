using AutoMapper;
using Moq;
using OrgX.Projects.Api.Application.AppModels;
using Entities = OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using OrgX.Projects.Api.Application.AppServices;
using System.Linq.Expressions;
using System.Collections;
using OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Tests.Application.AppServices;

public class TaskAppServiceTests
{
    [Fact]
    public void Add_Task_Count_Limit_Reached_Throws_Exception()
    {
        // Arrange
        var repositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new TaskAppService(repositoryMock.Object, mapperMock.Object);
        var projectId = Guid.NewGuid();
        var tasks = Enumerable.Range(0, 21).Select(i => new Entities.Task(Guid.NewGuid(), $"Task {i}", "Detail", 1, 1, null, projectId)).ToList();
        var taskAppModel = new TaskAppModel(Guid.NewGuid(), "New", "New", 0, 2, null, projectId);

        repositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Entities.Task, bool>>>())).Returns(tasks.AsQueryable());

        // Act & Assert
        Assert.Throws<Exception>(() => service.Add(taskAppModel));
    }

    [Fact]
    public void GetAll_Returns_Tasks_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new TaskAppService(repositoryMock.Object, mapperMock.Object);
        var projectId = Guid.NewGuid();
        var tasks = Enumerable.Range(0, 5).Select(i => new Entities.Task(Guid.NewGuid(), $"Task {i}", "Detail", 1, 1, null, projectId)).ToList();
        var expected = tasks.Select(t => new TaskAppModel(t.Id, t.Title, t.Detail, t.Status, t.Priority, t.EndDate, t.ProjectId)).ToList();

        mapperMock.Setup(mapper => mapper.Map<IEnumerable<TaskAppModel>>(It.IsAny<IEnumerable<Entities.Task>>()))
           .Returns(expected);

        repositoryMock.Setup(repo => repo.GetAll(It.IsAny< Expression<Func<Entities.Task, bool>>>())).Returns(tasks.AsQueryable());

        // Act
        var result = service.GetAll(projectId).ToList();

        // Assert
        Assert.Equal(expected.Count(), result.Count);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetById_Returns_Task_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new TaskAppService(repositoryMock.Object, mapperMock.Object);
        var taskId = Guid.NewGuid();
        var task = new Entities.Task(taskId, "Test Task", "Detail", 1, 1, null, Guid.NewGuid());
        var expected = new TaskAppModel(task.Id, task.Title, task.Detail, task.Status, task.Priority, task.EndDate, task.ProjectId);

        mapperMock.Setup(mapper => mapper.Map<TaskAppModel>(It.IsAny<Entities.Task>()))
           .Returns(expected);

        repositoryMock.Setup(repo => repo.GetById(taskId)).Returns(task);

        // Act
        var result = service.GetById(taskId);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Report_Returns_Report_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new TaskAppService(repositoryMock.Object, mapperMock.Object);
        var userId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var project = new Project(projectId, "Test", userId, null);
        var tasks = Enumerable.Range(0, 5).Select(i => new Entities.Task(Guid.NewGuid(), $"Task {i}", "Detail", 1, 1, DateTime.Now.AddDays(-15), projectId, project)).ToList();
        tasks.AddRange(Enumerable.Range(0, 3).Select(i => new Entities.Task(Guid.NewGuid(), $"Task {i}", "Detail", 1, 1, DateTime.Now.AddDays(-35), projectId, project)));
        var expected = tasks.GroupBy(t => t.ProjectId).Select(g => new { userId = g.Key, count = g.Count() }).ToList();

        repositoryMock.Setup(repo => repo.GetAll(It.IsAny< Expression<Func<Entities.Task, bool>>>()))
                      .Returns(tasks.AsQueryable());

        // Act
        var result = service.Report();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable>(result);
        var resultList = (result).Cast<object>().ToList();
        Assert.Equal(expected.Count, resultList.Count);
    }
}
