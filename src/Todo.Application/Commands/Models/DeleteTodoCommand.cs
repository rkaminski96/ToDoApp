using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Commands.Models
{
    public class DeleteTodoCommand : ICommand
    {
        public DeleteTodoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; protected set; }
    }
}
