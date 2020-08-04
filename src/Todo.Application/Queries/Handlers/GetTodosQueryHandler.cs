using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Dtos;
using TodoApp.Application.Queries.Models;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Extensions;
using TodoApp.Domain.Helpers;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Queries.Handlers
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodoPreviewListDto>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public GetTodosQueryHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }

        public async Task<TodoPreviewListDto> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = todoRepository.GetQueryable();

            if (request.Status == TodoStatus.Done)
            {
                todos = todos.Where(x => x.Status == TodoStatus.Done);
            }
            
            if (request.Status == TodoStatus.Todo)
            {
                todos = todos.Where(x => x.Status == TodoStatus.Todo);
            }

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                todos = todos.Where(x => x.Title.Contains(request.Search) || x.Description.Contains(request.Search));
            }

            todos = todos.OrderByDescending(x => x.Priority);
            var totalCount = await todos.CountAsync();

            todos = todos.ApplyPagination(request.PageNumber, request.PageSize);
            
            var todoList = mapper.Map<List<Todo>, List<TodoPreviewDto>>(await todos.ToListAsync());
            var paginationMetadata = new PaginationMetadata(request.PageNumber, request.PageSize, totalCount);

            return new TodoPreviewListDto()
            {
                TodoPreviewDtos = todoList,
                PaginationMetadata = paginationMetadata
            };
        }
    }
}
