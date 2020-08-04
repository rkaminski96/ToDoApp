using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Commands.Models;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Commands.Handlers
{
    public class ChangeTodoPriorityCommandHandler : IRequestHandler<ChangeTodoPriorityCommand, Unit>
    {
        private readonly ITodoRepository todoRepository;

        public ChangeTodoPriorityCommandHandler(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(ChangeTodoPriorityCommand request, CancellationToken cancellationToken)
        {
            var todo = await todoRepository.GetByIdAsync(request.Id);
            if (todo == null)
            {
                throw new TodoException(ErrorCode.TodoNotExist);
            }

            todo.SetPriority(request.TodoPriority);

            todoRepository.Update(todo);
            await todoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
