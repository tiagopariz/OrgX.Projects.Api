using AutoMapper;
using Moq;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Application.AppServices;
using Entities = OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Tests.Application.AppServices;

public class ProjectAppServiceTests
{
    [Fact]
    public void Add_Project_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IProjectRepository>();
        var taskRepositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new ProjectAppService(repositoryMock.Object, taskRepositoryMock.Object, mapperMock.Object);
        var project = new ProjectAppModel(Guid.NewGuid(), "Test Project", Guid.NewGuid());

        // Act
        service.Add(project);

        // Assert
        repositoryMock.Verify(repo => repo.Add(It.IsAny<Project>()), Times.Once);
    }

    [Fact]
    public void Remove_Project_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IProjectRepository>();
        var taskRepositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new ProjectAppService(repositoryMock.Object, taskRepositoryMock.Object, mapperMock.Object);
        var projectId = Guid.NewGuid();
        var project = new ProjectAppModel(projectId, "Test Project", Guid.NewGuid());

        repositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Project, bool>>>())).Returns(Enumerable.Empty<Project>().AsQueryable());

        // Act
        service.Remove(project);

        // Assert
        repositoryMock.Verify(repo => repo.Remove(It.IsAny<Project>()), Times.Once);
    }

    [Fact]
    public void Remove_Project_Throws_Exception_When_Open_Tasks_Exist()
    {
        // Arrange
        var repositoryMock = new Mock<IProjectRepository>();
        var taskRepositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new ProjectAppService(repositoryMock.Object, taskRepositoryMock.Object, mapperMock.Object);
        var projectId = Guid.NewGuid();
        var project = new ProjectAppModel(projectId, "Test Project", Guid.NewGuid());

        var tasks = new List<Entities.Task> { new Entities.Task(Guid.NewGuid(), "Test Task", "", 0, 0, null, projectId) };

        mapperMock.Setup(mapper => mapper.Map<ProjectAppModel>(It.IsAny<Project>()))
           .Returns(project);

        taskRepositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Entities.Task, bool>>>())).Returns(tasks.AsQueryable());

        // Act && Assert
        Assert.Throws<Exception>(() => service.Remove(project));
    }

    [Fact]
    public void GetAll_Returns_Projects_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IProjectRepository>();
        var taskRepositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new ProjectAppService(repositoryMock.Object, taskRepositoryMock.Object, mapperMock.Object);
        var userId = Guid.NewGuid();
        var projects = new List<Project> { new Project(Guid.NewGuid(), "Test Project", userId, null) };
        var expected = projects.Select(p => new ProjectAppModel(p.Id, p.Title, p.UserId));

        mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProjectAppModel>>(It.IsAny<IEnumerable<Project>>()))
                   .Returns(expected);

        repositoryMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Project, bool>>>())).Returns(projects.AsQueryable());

        // Act
        var result = service.GetAll(userId).ToList();

        // Assert
        Assert.Equal(expected.Count(), result.Count());

    }

    [Fact]
    public void GetById_Returns_Project_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IProjectRepository>();
        var taskRepositoryMock = new Mock<ITaskRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new ProjectAppService(repositoryMock.Object, taskRepositoryMock.Object, mapperMock.Object);
        var projectId = Guid.NewGuid();
        var project = new Project(projectId, "Test Project", Guid.NewGuid(), null);
        var expected = new ProjectAppModel(project.Id, project.Title, project.UserId);


        mapperMock.Setup(mapper => mapper.Map<ProjectAppModel>(It.IsAny<Project>()))
                   .Returns(expected);

        repositoryMock.Setup(repo => repo.GetById(projectId)).Returns(project);

        // Act
        var result = service.GetById(projectId);

        // Assert
        Assert.Equal(project.Id, result.Id);
    }
}