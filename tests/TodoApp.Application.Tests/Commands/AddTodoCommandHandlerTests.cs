using AutoFixture;
using Moq;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Handlers;
using TodoApp.Application.Commands.Models;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Interfaces;
using Xunit;

namespace TodoApp.Application.Tests.Commands
{
    public class AddTodoCommandHandlerTests 
    {
        private readonly Fixture fixture;
        private readonly Mock<ITodoRepository> todoRepositoryMock;
        private readonly AddTodoCommandHandler sut;

        public AddTodoCommandHandlerTests()
        {
            fixture = new Fixture();
            todoRepositoryMock = new Mock<ITodoRepository>();
            sut = new AddTodoCommandHandler(todoRepositoryMock.Object);
        }

        [Fact]
        public async Task WhenHandlingCommand_ThenAddTodoWithProperData()
        {
            // Arrange
            var request = Create();

            // Act
            await sut.Handle(request, default);

            // Assert
            todoRepositoryMock.Verify(x => x.AddAsync(It.Is<Todo>(x =>
                x.Title == request.Title &&
                x.Description == request.Description &&
                x.CompletionDate == request.CompletionDate &&
                x.Priority == x.Priority &&
                x.Status == TodoStatus.Todo)), Times.Once);
        }

        [Fact]
        public async Task WhenHandlingCommand_ThenSaveChanges()
        {
            // Arrange
            var request = Create();

            // Act
            await sut.Handle(request, default);

            // Assert
            todoRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        private AddTodoCommand Create()
        {
            return fixture
                .Build<AddTodoCommand>()
                .Create();
        }
    }
}
