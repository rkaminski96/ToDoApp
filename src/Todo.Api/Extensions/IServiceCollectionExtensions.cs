using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Todo.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo app", Version = "v1" });
            });
        }
    }
}
