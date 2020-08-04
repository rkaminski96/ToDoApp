using System;
using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Entities
{
    public class Todo
    {
        private Todo() { }

        public Todo(string title, string description, DateTime completionDate, TodoPriority todoPriority)
        {
            SetTitle(title);
            SetDescription(description);
            SetCompletionDate(completionDate);
            SetPriority(todoPriority);
            Status = TodoStatus.Todo;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CompletionDate { get; private set; }
        public TodoStatus Status { get; private set; }
        public TodoPriority Priority { get; private set; }

        public void SetTitle(string title)
            => Title = title;

        public void SetDescription(string description)
            => Description = description;

        public void SetCompletionDate(DateTime completionDate)
            => CompletionDate = completionDate;

        public void SetStatus(TodoStatus status)
            => Status = status;

        public void SetPriority(TodoPriority priority)
            => Priority = priority;
    }
}
