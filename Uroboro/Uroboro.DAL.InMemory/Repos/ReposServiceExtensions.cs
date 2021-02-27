using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Uroboro.DAL.InMemory.Contexts;
using Uroboro.DAL.InMemory.Repos.Todo;

namespace Uroboro.DAL.InMemory.Repos
{
    public static class ReposServiceExtensions
    {
        public static IServiceCollection AddTodoRepo(this IServiceCollection services)
        {
            services.AddDbContext<TodoItemsContext>(
                options => options.UseInMemoryDatabase("TodoItems"));
            services.AddTransient<ITodoItemsRepo, TodoItemsRepo>();

            return services;
        }
    }
}