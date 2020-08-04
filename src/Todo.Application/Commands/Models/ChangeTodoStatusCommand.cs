using MediatR;
using System.ComponentModel.DataAnnotations;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Commands.Models
{
    public class ChangeTodoStatusCommand : IRequest
    {
        public int Id { get; protected set; }

        [Required]
        [EnumDataType(typeof(TodoStatus))]
        public TodoStatus TodoStatus { get; set; }

        public ChangeTodoStatusCommand SetTodoId(int id)
        {
            Id = id;
            return this;
        }
    }
}
