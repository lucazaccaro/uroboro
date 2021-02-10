using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Uroboro.DAL.InMemory.Repos.Todo;

namespace Uroboro.DAL.InMemory.Repos
{
    public static class ReposServiceExtensions
    {
        public static IServiceCollection AddTodoRepo(this IServiceCollection services)
        {
            services.AddTransient<ITodoItemsRepo, TodoItemsRepo>();

            return services;
        }
    }
}