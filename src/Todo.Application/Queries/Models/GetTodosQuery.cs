using MediatR;
using System.ComponentModel.DataAnnotations;
using TodoApp.Application.Dtos;
using TodoApp.Domain.Enums;

namespace TodoApp.Application.Queries.Models
{
    public class GetTodosQuery : IRequest<TodoPreviewListDto>
    {
        const int MAX_PAGE_SIZE = 15;
        private int pageSize = 10;

        [MaxLength(1000)]
        public string Search { get; set; }

        public TodoStatus Status { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int PageNumber { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than or equal to {1}")]
        public int PageSize 
        {
            get => pageSize;
            set => pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
        }
    }
}
