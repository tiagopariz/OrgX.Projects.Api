using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.WebApi.Controllers;
using OrgX.Projects.Api.WebApi.DeleteModels;
using OrgX.Projects.Api.WebApi.GetModels;
using OrgX.Projects.Api.WebApi.PostModels;

namespace OrgX.Projects.Api.Tests.WebApi.Controllers;

public class ProjectsControllerTests
{
    [Fact]
    public void Get_WhenCalled_ReturnsOkResultWithProjects()
    {
        // Arrange
        var mockProjectAppService = new Mock<IProjectAppService>();
        var mockMapper = new Mock<IMapper>();

        var userId = Guid.NewGuid();
        var projects = new List<ProjectAppModel>
            {
                new ProjectAppModel(Guid.NewGuid(), "Project 1", userId),
                new ProjectAppModel(Guid.NewGuid(), "Project 2", userId)
            };
        mockProjectAppService.Setup(service => service.GetAll(userId)).Returns(projects);

        var expectedResponse = new GetResponse<IEnumerable<ProjectGetModel>>(
            new GetMetadata(),
            new List<ProjectGetModel>
            {
                    new ProjectGetModel((Guid)projects[0].Id, projects[0].Title, projects[0].UserId, null),
                    new ProjectGetModel((Guid)projects[1].Id, projects[1].Title, projects[1].UserId, null)
            });
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<ProjectGetModel>>(projects)).Returns(expectedResponse.Results);

        var controller = new ProjectsController(mockProjectAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Get(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<GetResponse<IEnumerable<ProjectGetModel>>>(okResult.Value);
        Assert.Equal(expectedResponse.Results, response.Results);
    }

    [Fact]
    public void Post_WhenCalledWithValidModel_ReturnsCreatedAtRouteResult()
    {
        // Arrange
        var mockProjectAppService = new Mock<IProjectAppService>();
        var mockMapper = new Mock<IMapper>();

        var projectPostModel = new ProjectPostModel("Test Project", Guid.NewGuid());
        var projectAppModel = new ProjectAppModel((Guid)projectPostModel.Id, projectPostModel.Title, projectPostModel.UserId);
        var projectGetModel = new ProjectGetModel((Guid)projectAppModel.Id, projectAppModel.Title, projectAppModel.UserId, null);

        mockMapper.Setup(mapper => mapper.Map<ProjectPostModel, ProjectAppModel>(projectPostModel)).Returns(projectAppModel);
        mockMapper.Setup(mapper => mapper.Map<ProjectAppModel, ProjectGetModel>(projectAppModel)).Returns(projectGetModel);

        var controller = new ProjectsController(mockProjectAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Post(projectPostModel);

        // Assert
        var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
        var postResponse = Assert.IsType<PostResponse<ProjectGetModel>>(createdAtRouteResult.Value);
        Assert.Equal(projectGetModel, postResponse.Results);
    }

    [Fact]
    public void Delete_WhenCalledWithValidModel_ReturnsNoContentResult()
    {
        // Arrange
        var mockProjectAppService = new Mock<IProjectAppService>();
        var mockMapper = new Mock<IMapper>();

        var projectDeleteModel = new ProjectDeleteModel(Guid.NewGuid(), "Test Project", Guid.NewGuid());

        var controller = new ProjectsController(mockProjectAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Delete(projectDeleteModel);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
