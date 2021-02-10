using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
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