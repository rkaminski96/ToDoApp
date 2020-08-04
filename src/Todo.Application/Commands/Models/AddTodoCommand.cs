using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Commands.Models
{
    public class AddTodoCommand : IRequest
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CompletionDate { get; set; }

        [Required]
        [EnumDataType(typeof(TodoPriority))]
        public TodoPriority Priority { get; set; }
    }
}
