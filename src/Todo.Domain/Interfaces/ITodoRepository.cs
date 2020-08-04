using System.Linq;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> GetByIdAsync(int id);
        IQueryable<Todo> GetQueryable();
        Task AddAsync(Todo todo);
        void Update(Todo todo);
        void Delete(Todo todo);
        Task SaveChangesAsync();
    }
}
