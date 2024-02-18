using AutoMapper;
using Moq;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Application.AppServices;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;

namespace OrgX.Projects.Api.Tests.Application.AppServices;

public class CommentAppServiceTests
{
    [Fact]
    public void Add_WhenCalled_ShouldAddComment()
    {
        // Arrange
        var mockRepository = new Mock<ICommentRepository>();
        var mockMapper = new Mock<IMapper>();

        var appService = new CommentAppService(mockRepository.Object, mockMapper.Object);

        var commentAppModel = new CommentAppModel(Guid.NewGuid(), "Test Comment", Guid.NewGuid());
        var commentEntity = new Comment(Guid.NewGuid(), commentAppModel.TaskId, commentAppModel.Content);

        mockMapper.Setup(mapper => mapper.Map<Comment>(commentAppModel)).Returns(commentEntity);

        // Act
        appService.Add(commentAppModel);

        // Assert
        mockRepository.Verify(repository => repository.Add(It.Is<Comment>(c => c.Id == commentEntity.Id)), Times.Once);
    }

    [Fact]
    public void Remove_WhenCalled_ShouldRemoveComment()
    {
        // Arrange
        var mockRepository = new Mock<ICommentRepository>();
        var mockMapper = new Mock<IMapper>();

        var appService = new CommentAppService(mockRepository.Object, mockMapper.Object);

        var commentAppModel = new CommentAppModel(Guid.NewGuid(), "Test Comment", Guid.NewGuid());
        var commentEntity = new Comment(Guid.NewGuid(), commentAppModel.TaskId, commentAppModel.Content);

        mockMapper.Setup(mapper => mapper.Map<Comment>(commentAppModel)).Returns(commentEntity);

        // Act
        appService.Remove(commentAppModel);

        // Assert
        mockRepository.Verify(repository => repository.Remove(It.Is<Comment>(c => c.Id == commentEntity.Id)), Times.Once);
    }

    [Fact]
    public void Update_WhenCalled_ShouldUpdateComment()
    {
        // Arrange
        var mockRepository = new Mock<ICommentRepository>();
        var mockMapper = new Mock<IMapper>();

        var appService = new CommentAppService(mockRepository.Object, mockMapper.Object);

        var commentAppModel = new CommentAppModel(Guid.NewGuid(), "Test Comment", Guid.NewGuid());
        var commentEntity = new Comment(Guid.NewGuid(), commentAppModel.TaskId, commentAppModel.Content);

        mockMapper.Setup(mapper => mapper.Map<Comment>(commentAppModel)).Returns(commentEntity);

        // Act
        appService.Update(commentAppModel);

        // Assert
        mockRepository.Verify(repository => repository.Update(It.Is<Comment>(c => c.Id == commentEntity.Id)), Times.Once);
    }


    [Fact]
    public void GetById_WhenCalled_ShouldReturnComment()
    {
        // Arrange
        var mockRepository = new Mock<ICommentRepository>();
        var mockMapper = new Mock<IMapper>();

        var appService = new CommentAppService(mockRepository.Object, mockMapper.Object);

        var commentId = Guid.NewGuid();
        var commentEntity = new Comment(commentId, Guid.NewGuid(), "Test Comment");
        var commentAppModel = new CommentAppModel(commentId, "Test Comment", Guid.NewGuid());

        mockRepository.Setup(repository => repository.GetById(commentId)).Returns(commentEntity);
        mockMapper.Setup(mapper => mapper.Map<CommentAppModel>(commentEntity)).Returns(commentAppModel);

        // Act
        var result = appService.GetById(commentId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CommentAppModel>(result);
        Assert.Equal(commentAppModel, result);
    }
}