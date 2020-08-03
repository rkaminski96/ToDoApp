using System;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Commands.Models
{
    public class AddTodoCommand : ICommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public TodoPriority Priority { get; set; }
    }
}
