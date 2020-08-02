using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TodoApp.Application.Interfaces;
using TodoApp.Infrastructure.Profiles;

namespace TodoApp.Api.Extensions
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

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TodoProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IQuery<>).Assembly);
        }
    }
}
