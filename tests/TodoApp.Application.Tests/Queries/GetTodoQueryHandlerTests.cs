using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using TodoApp.Application.Dtos;
using TodoApp.Application.Queries.Handlers;
using TodoApp.Application.Queries.Models;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;
using Xunit;

namespace TodoApp.Application.Tests.Queries
{
    public class GetTodoQueryHandlerTests
    {
        private readonly Fixture fixture;
        private readonly Mock<ITodoRepository> todoRepositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly GetTodoQueryHandler sut;

        public GetTodoQueryHandlerTests()
        {
            fixture = new Fixture();
            todoRepositoryMock = new Mock<ITodoRepository>();
            mapperMock = new Mock<IMapper>();

            sut = new GetTodoQueryHandler(
                todoRepositoryMock.Object,
                mapperMock.Object);
        }

        [Fact]
        public async Task WhenHandlingCommand_ThenGetTodoFromRepository()
        {
            // Arrange
            var todo = CreateTodo();
            var request = Create();

            todoRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(todo);

            // Act
            await sut.Handle(request, default);

            // Assert
            todoRepositoryMock.Verify(x => x.GetByIdAsync(request.Id), Times.Once);
        }

        [Fact]
        public async Task WhenHandlingCommand_AndTodoNotExist_ThenThrowExceptionWithProperErrorCode()
        {
            // Arrange
            var request = Create();

            todoRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Todo)null);

            // Act
            Func<Task> result = () => sut.Handle(request, default);

            // Assert
            var exception = await result.Should().ThrowAsync<TodoException>();
            exception.Which.ErrorCode.Should().BeEquivalentTo(ErrorCode.TodoNotExist);
        }

        [Theory]
        [AutoData]
        public async Task WhenHandlingCommand_AndTodoExist_ThenMapToTodoDto(TodoDto todoDto)
        {
            // Arrange
            var request = Create();
            var todo = CreateTodo();

            todoRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(todo);
            mapperMock.Setup(x => x.Map<Todo, TodoDto>(It.IsAny<Todo>()))
                .Returns(todoDto);

            // Act
            await sut.Handle(request, default);

            // Assert
            mapperMock.Verify(x => x.Map<Todo, TodoDto>(todo), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task WhenHandlingCommand_ThenReturnTodoDto(TodoDto todoDto)
        {
            // Arrange
            var request = Create();
            var todo = CreateTodo();

            todoRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(todo);
            mapperMock.Setup(x => x.Map<Todo, TodoDto>(It.IsAny<Todo>()))
                .Returns(todoDto);

            // Act
            var result = await sut.Handle(request, default);

            // Assert
            result.Should().BeEquivalentTo(todoDto);
        }


        private GetTodoQuery Create()
        {
            return fixture
                .Build<GetTodoQuery>()
                .Create();
        }

        private Todo CreateTodo()
        {
            return fixture
                .Build<Todo>()
                .Create();
        }
    }
}
