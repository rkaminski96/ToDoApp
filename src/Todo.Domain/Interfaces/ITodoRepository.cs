using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
