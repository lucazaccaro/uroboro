using Microsoft.Extensions.DependencyInjection;
using Uroboro.BL.Managers.Todo;
using Uroboro.DAL.InMemory.Repos;

namespace Uroboro.BL.Managers
{
    public static class ManagersServiceExtensions
    {
        public static IServiceCollection AddTodoManager(this IServiceCollection services)
        {
            services
                .AddTodoRepo()
                .AddTransient<ITodoItemsManager, TodoItemsManager>();

            return services;
        }
    }
}