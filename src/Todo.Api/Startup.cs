using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Todo.Api.Extensions;
using Todo.Api.Filters;
using Todo.Api.Middleware;

namespace Todo.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x => 
                x.Filters.Add(typeof(ModelStateFilter)));
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            }
            else
            {
                app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
            }

            app.UseSwaggerUserInterface();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
