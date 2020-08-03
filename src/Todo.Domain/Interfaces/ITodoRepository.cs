using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> GetByIdAsync(int id);
        Task AddAsync(Todo todo);
        void Update(Todo todo);
        void Delete(Todo todo);
        Task SaveChangesAsync();
    }
}
