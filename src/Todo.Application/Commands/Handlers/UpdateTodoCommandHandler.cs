using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Models;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Commands.Handlers
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Unit>
    {
        private readonly ITodoRepository todoRepository;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await todoRepository.GetByIdAsync(request.Id);
            if (todo == null)
            {
                throw new TodoException(ErrorCode.TodoNotExist);
            }

            todo.Update(request.Title, request.Description, request.CompletionDate);

            todoRepository.Update(todo);
            await todoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
