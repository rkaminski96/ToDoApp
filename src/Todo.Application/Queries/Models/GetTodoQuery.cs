using TodoApp.Application.Dtos;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Queries.Models
{
    public class GetTodoQuery : IQuery<TodoDto>
    {
        public GetTodoQuery(int id)
        {
            Id = id;  
        }

        public int Id { get; protected set; }
    }
}
