using AutoMapper;
using TodoApp.Application.Dtos;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>();
        }
    }
}
