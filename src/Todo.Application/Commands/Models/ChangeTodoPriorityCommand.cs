using MediatR;
using System.ComponentModel.DataAnnotations;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Commands.Models
{
    public class ChangeTodoPriorityCommand : IRequest
    {
        public int Id { get; protected set; }

        [Required]
        [EnumDataType(typeof(TodoPriority))]
        public TodoPriority TodoPriority { get; set; }

        public ChangeTodoPriorityCommand SetTodoId(int id)
        {
            Id = id;
            return this;
        }
    }
}
