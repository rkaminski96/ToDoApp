using System.Linq;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : Todo
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
