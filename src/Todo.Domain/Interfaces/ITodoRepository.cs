using System.Threading.Tasks;

namespace TodoApp.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task SaveChangesAsync();
    }
}
