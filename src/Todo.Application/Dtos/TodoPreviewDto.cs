using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Dtos
{
    public class TodoPreviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CompletionDate { get; set; }
        public TodoStatus Status { get; set; }
        public TodoPriority Priority { get; set; }
    }
}
