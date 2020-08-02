using Microsoft.Extensions.DependencyInjection;
using TodoApp.Domain.Interfaces;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Infrastructure.Modules
{
    public static class RepositoriesModule
    {
        public static void AddRepositoriesModule(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
