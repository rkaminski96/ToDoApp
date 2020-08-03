using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Models;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Commands.Handlers
{
    public class AddTodoCommandHandler : IRequestHandler<AddTodoCommand, Unit>
    {
        private readonly ITodoRepository todoRepository;

        public AddTodoCommandHandler(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo(request.Title, request.Description, request.CompletionDate, request.Priority);

            await todoRepository.AddAsync(todo);
            await todoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
