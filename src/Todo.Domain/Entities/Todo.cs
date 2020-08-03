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
        public TodoPriority Priority { get; protected set; }

        protected Todo() { }

        public Todo(string title, string description, DateTime completionDate, TodoPriority todoPriority)
        {
            Title = title;
            Description = description;
            CompletionDate = completionDate;
            Priority = todoPriority;
            Status = TodoStatus.Todo;
        }

        public void Update(string title, string description, DateTime completionDate)
        {
            Title = title;
            Description = description;
            CompletionDate = completionDate;
        }

        public void SetStatus(TodoStatus status)
        {
            Status = status;
        }

        public void SetPriority(TodoPriority priority)
        {
            Priority = priority;
        }
    }
}
