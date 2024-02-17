using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.WebApi.Controllers;
using OrgX.Projects.Api.WebApi.DeleteModels;
using OrgX.Projects.Api.WebApi.Enums;
using OrgX.Projects.Api.WebApi.GetModels;
using OrgX.Projects.Api.WebApi.PostModels;

namespace OrgX.Projects.Api.Tests.WebApi.Controllers;

public class TasksControllerTests
{
    [Fact]
    public void Get_WhenCalled_ReturnsOkResultWithTasks()
    {
        // Arrange
        var mockTaskAppService = new Mock<ITaskAppService>();
        var mockMapper = new Mock<IMapper>();

        var projectId = Guid.NewGuid();
        var tasks = new List<TaskAppModel>
            {
                new TaskAppModel(Guid.NewGuid(), "Task 1", "Detail 1", 1, 1, DateTime.Now.AddDays(1), projectId),
                new TaskAppModel(Guid.NewGuid(), "Task 2", "Detail 2", 1, 2, DateTime.Now.AddDays(2), projectId)
            };
        mockTaskAppService.Setup(service => service.GetAll(projectId)).Returns(tasks);

        var expectedResponse = new GetResponse<IEnumerable<TaskGetModel>>(
            new GetMetadata(),
            new List<TaskGetModel>
            {
                    new TaskGetModel((Guid)tasks[0].Id, tasks[0].Title, tasks[0].Detail, (Status)tasks[0].Status, (Priority)tasks[0].Priority, tasks[0].EndDate, tasks[0].ProjectId, null),
                    new TaskGetModel((Guid)tasks[1].Id, tasks[1].Title, tasks[1].Detail, (Status)tasks[1].Status, (Priority)tasks[1].Priority, tasks[1].EndDate, tasks[1].ProjectId, null)
            });
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<TaskGetModel>>(tasks)).Returns(expectedResponse.Results);

        var controller = new TasksController(mockTaskAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Get(projectId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<GetResponse<IEnumerable<TaskGetModel>>>(okResult.Value);

        Assert.Equal(expectedResponse.Results, response.Results);
    }

    [Fact]
    public void Report_WhenCalled_ReturnsOkResultWithReportData()
    {
        // Arrange
        var mockTaskAppService = new Mock<ITaskAppService>();
        var mockMapper = new Mock<IMapper>();

        var reportData = new List<object>
            {
                new { Id = Guid.NewGuid(), Title = "Task 1", Detail = "Detail 1", Status = 1, Priority = 1, EndDate = DateTime.Now.AddDays(1), ProjectId = Guid.NewGuid() },
                new { Id = Guid.NewGuid(), Title = "Task 2", Detail = "Detail 2", Status = 1, Priority = 2, EndDate = DateTime.Now.AddDays(2), ProjectId = Guid.NewGuid() }
            };
        mockTaskAppService.Setup(service => service.Report()).Returns(reportData);

        var controller = new TasksController(mockTaskAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Report();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(reportData, okResult.Value);
    }

    [Fact]
    public void Post_WhenCalledWithValidModel_ReturnsCreatedAtRouteResult()
    {
        // Arrange
        var mockTaskAppService = new Mock<ITaskAppService>();
        var mockMapper = new Mock<IMapper>();

        var taskPostModel = new TaskPostModel("Test Task", "Test Detail", Status.ToDo, Priority.Medium, Guid.NewGuid());
        var taskAppModel = new TaskAppModel(taskPostModel.Id, taskPostModel.Title, taskPostModel.Detail, (short)taskPostModel.Status, (short)taskPostModel.Priority, null, taskPostModel.ProjectId);
        var taskGetModel = new TaskGetModel((Guid)taskAppModel.Id, taskAppModel.Title, taskAppModel.Detail, (Status)taskAppModel.Status, (Priority)taskAppModel.Priority, null, taskAppModel.ProjectId, null);

        mockMapper.Setup(mapper => mapper.Map<TaskPostModel, TaskAppModel>(taskPostModel)).Returns(taskAppModel);
        mockMapper.Setup(mapper => mapper.Map<TaskAppModel, TaskGetModel>(taskAppModel)).Returns(taskGetModel);

        var controller = new TasksController(mockTaskAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Post(taskPostModel);

        // Assert
        var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
        var postResponse = Assert.IsType<PostResponse<TaskGetModel>>(createdAtRouteResult.Value);
        Assert.Equal(taskGetModel, postResponse.Results);
    }

    [Fact]
    public void Delete_WhenCalledWithValidModel_ReturnsNoContentResult()
    {
        // Arrange
        var mockTaskAppService = new Mock<ITaskAppService>();
        var mockMapper = new Mock<IMapper>();

        var taskDeleteModel = new TaskDeleteModel(Guid.NewGuid(), "Test Task", "Test Detail", Status.Doing, Priority.Low, null, Guid.NewGuid());

        var controller = new TasksController(mockTaskAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Delete(taskDeleteModel);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
