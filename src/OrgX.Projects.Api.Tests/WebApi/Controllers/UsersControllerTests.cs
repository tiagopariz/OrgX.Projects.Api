using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.WebApi.Controllers;
using OrgX.Projects.Api.WebApi.GetModels;


namespace OrgX.Projects.Api.Tests.WebApi.Controllers;

public class UsersControllerTests
{
    [Fact]
    public void Get_WhenCalled_ReturnsOkResultWithUsers()
    {
        // Arrange
        var mockUserAppService = new Mock<IUserAppService>();
        var mockMapper = new Mock<IMapper>();

        var users = new List<UserAppModel>
            {
                new UserAppModel(Guid.NewGuid(), "User1", "Admin"),
                new UserAppModel(Guid.NewGuid(), "User2", "User")
            };
        mockUserAppService.Setup(service => service.GetAll()).Returns(users);

        var expectedResponse = new GetResponse<IEnumerable<UserGetModel>>(
            new GetMetadata(),
            new List<UserGetModel>
            {
                    new UserGetModel((Guid)users[0].Id, users[0].Username, users[0].Role),
                    new UserGetModel((Guid)users[1].Id, users[1].Username, users[1].Role)
            });
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<UserGetModel>>(users)).Returns(expectedResponse.Results);

        var controller = new UsersController(mockUserAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<GetResponse<IEnumerable<UserGetModel>>>(okResult.Value);
        Assert.Equal(expectedResponse.Results, response.Results);
    }

    [Fact]
    public void Get_WhenUserListIsEmpty_ReturnsOkResultWithEmptyList()
    {
        // Arrange
        var mockUserAppService = new Mock<IUserAppService>();
        var mockMapper = new Mock<IMapper>();

        mockUserAppService.Setup(service => service.GetAll()).Returns(new List<UserAppModel>());
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<UserGetModel>>(It.IsAny<IEnumerable<UserAppModel>>()))
                  .Returns(new List<UserGetModel>());

        var controller = new UsersController(mockUserAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<GetResponse<IEnumerable<UserGetModel>>>(okResult.Value);
        Assert.Empty(response.Results);
    }
}
