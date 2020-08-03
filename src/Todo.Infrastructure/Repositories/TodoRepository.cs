using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Exceptions;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Infrastructure.Repositories
{
    internal class TodoRepository : ITodoRepository
    {
        private readonly TodoContext context;

        public TodoRepository(TodoContext context) 
        {
            this.context = context;
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Todo todo)
        {
            await context.AddAsync(todo);
        }

        public void Update(Todo todo)
        {
            context.Update(todo);
        }

        public void Delete(Todo todo)
        {
            context.Remove(todo);
        }

        public async Task SaveChangesAsync()
        {
            if (await context.SaveChangesAsync() < 0)
                throw new TodoException(ErrorCode.DatabaseSavingException);
        }
    }
}
