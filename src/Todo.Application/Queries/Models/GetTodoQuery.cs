using MediatR;
using TodoApp.Application.Dtos;

namespace TodoApp.Application.Queries.Models
{
    public class GetTodoQuery : IRequest<TodoDto>
    {
        public GetTodoQuery(int id)
        {
            Id = id;  
        }

        public int Id { get; protected set; }
    }
}
