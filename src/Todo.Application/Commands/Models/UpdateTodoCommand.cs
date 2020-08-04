using MediatR;
using System;

namespace TodoApp.Application.Commands.Models
{
    public class UpdateTodoCommand : IRequest
    {
        public int Id { get; protected set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }

        public UpdateTodoCommand SetTodoId(int id)
        {
            Id = id;
            return this;
        }
    }
}
