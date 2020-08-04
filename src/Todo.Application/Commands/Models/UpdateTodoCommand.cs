using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Application.Commands.Models
{
    public class UpdateTodoCommand : IRequest
    {
        public int Id { get; protected set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CompletionDate { get; set; }

        public UpdateTodoCommand SetTodoId(int id)
        {
            Id = id;
            return this;
        }
    }
}
