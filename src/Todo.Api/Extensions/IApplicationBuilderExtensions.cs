using Microsoft.AspNetCore.Builder;

namespace TodoApp.Api.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseSwaggerUserInterface(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo app");
            });
        }
    }
}
