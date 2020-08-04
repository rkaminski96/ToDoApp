using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Handlers;
using TodoApp.Application.Commands.Models;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;
using Xunit;

namespace TodoApp.Application.Tests.Commands
{
    public class ChangeTodoPriorityCommandHandlerTests 
    {
        private readonly Fixture fixture;
        private readonly Mock<ITodoRepository> todoRepositoryMock;
        private readonly ChangeTodoPriorityCommandHandler sut;

        public ChangeTodoPriorityCommandHandlerTests()
        {
            fixture = new Fixture();
            todoRepositoryMock = new Mock<ITodoRepository>();
            sut = new ChangeTodoPriorityCommandHandler(todoRepositoryMock.Object);
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

        [Fact]
        public async Task WhenHandlingCommand_AndTodoExist_ThenUpdateWithProperData()
        {
            // Arrange
            var todo = CreateTodo();
            var request = Create();

            todoRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(todo);

            // Act
            await sut.Handle(request, default);

            // Assert
            todoRepositoryMock.Verify(x => x.Update(It.Is<Todo>(x => 
                x.Priority == request.TodoPriority)), Times.Once);
        }

        [Fact]
        public async Task WhenHandlingCommand_ThenSaveChanges()
        {
            // Arrange
            var todo = CreateTodo();
            var request = Create();
            
            todoRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(todo);

            // Act
            await sut.Handle(request, default);

            // Assert
            todoRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        private ChangeTodoPriorityCommand Create()
        {
            return fixture
                .Build<ChangeTodoPriorityCommand>()
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
