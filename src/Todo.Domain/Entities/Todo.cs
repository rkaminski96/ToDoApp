using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Entities
{
    public class Todo
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CompletionDate { get; protected set; }
        public TodoStatus Status { get; protected set; }
    }
}
