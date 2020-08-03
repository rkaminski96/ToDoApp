using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Models;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Commands.Handlers
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, Unit>
    {
        private readonly ITodoRepository todoRepository;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await todoRepository.GetByIdAsync(request.Id);
            if (todo == null)
            {
                throw new TodoException(ErrorCode.TodoNotExist);
            }

            todoRepository.Delete(todo);
            await todoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
