using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Application.Dtos;
using TodoApp.Application.Queries.Models;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Queries.Handlers
{
    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoDto>
    {
        private readonly ITodoRepository todoRepository;
        private readonly IMapper mapper;

        public GetTodoQueryHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }

        public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todo = await todoRepository.GetByIdAsync(request.Id);
            if (todo == null)
            {
                throw new TodoException(ErrorCode.TodoNotExist);
            }

            var todoDto = mapper.Map<Todo, TodoDto>(todo);

            return todoDto;
        }
    }
}
