using AutoMapper;
using Moq;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Application.AppServices;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;

namespace OrgX.Projects.Api.Tests.Application.AppServices;

public class UserAppServiceTests
{
    [Fact]
    public void GetAll_Returns_All_Users_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IUserRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new UserAppService(repositoryMock.Object, mapperMock.Object);

        var users = new List<User>
            {
                new User(Guid.NewGuid(), "user1", "Manager"),
                new User(Guid.NewGuid(), "user2", "User")
            };

        var expected = users.Select(u => new UserAppModel(u.Id, u.Username, u.Role));

        repositoryMock.Setup(repo => repo.GetAll(null)).Returns(users.AsQueryable());
        mapperMock.Setup(mapper => mapper.Map<IEnumerable<UserAppModel>>(users)).Returns(expected);

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Equal(expected.Count(), result.Count());
    }

    [Fact]
    public void GetById_Returns_User_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IUserRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new UserAppService(repositoryMock.Object, mapperMock.Object);

        var userId = Guid.NewGuid();
        var user = new User(userId, "user1", "Manager");

        var expected = new UserAppModel(userId, user.Username, user.Role);

        repositoryMock.Setup(repo => repo.GetById(userId)).Returns(user);
        mapperMock.Setup(mapper => mapper.Map<UserAppModel>(user)).Returns(expected);

        // Act
        var result = service.GetById(userId);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAll_Returns_Empty_When_No_Users()
    {
        // Arrange
        var repositoryMock = new Mock<IUserRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new UserAppService(repositoryMock.Object, mapperMock.Object);

        repositoryMock.Setup(repo => repo.GetAll(null)).Returns(new List<User>().AsQueryable());

        // Act
        var result = service.GetAll();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetById_Returns_Default_When_User_Not_Found()
    {
        // Arrange
        var repositoryMock = new Mock<IUserRepository>();
        var mapperMock = new Mock<IMapper>();

        var service = new UserAppService(repositoryMock.Object, mapperMock.Object);

        var userId = Guid.NewGuid();

        repositoryMock.Setup(repo => repo.GetById(userId)).Returns((User)null);

        // Act
        var result = service.GetById(userId);

        // Assert
        Assert.Equal(default(UserAppModel), result);
    }
}