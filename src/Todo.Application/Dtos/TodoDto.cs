using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Dtos
{
    public class TodoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public TodoStatus Status { get; set; }
        public TodoPriority Priority { get; set; }
    }
}
