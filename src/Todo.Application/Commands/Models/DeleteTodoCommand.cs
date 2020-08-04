using MediatR;

namespace TodoApp.Application.Commands.Models
{
    public class DeleteTodoCommand : IRequest
    {
        public DeleteTodoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }
    }
}
