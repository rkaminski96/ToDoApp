using System.Collections.Generic;
using TodoApp.Domain.Helpers;

namespace TodoApp.Application.Dtos
{
    public class TodoPreviewListDto
    {
        public List<TodoPreviewDto> TodoPreviewDtos { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
    }
}
