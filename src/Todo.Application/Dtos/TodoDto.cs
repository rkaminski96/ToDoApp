using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Dtos
{
    public class TodoDto
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CompletionDate { get; protected set; }
        public TodoStatus Status { get; protected set; }
        public TodoPriority Priority { get; protected set; }
    }
}
