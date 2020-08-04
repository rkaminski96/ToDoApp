using MediatR;
using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Commands.Models
{
    public class AddTodoCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public TodoPriority Priority { get; set; }
    }
}
