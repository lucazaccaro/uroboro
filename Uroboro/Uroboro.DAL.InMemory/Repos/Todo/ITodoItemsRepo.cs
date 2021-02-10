using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uroboro.Common.Models;

namespace Uroboro.DAL.InMemory.Repos.Todo
{
    public interface ITodoItemsRepo
    {
        Task<IEnumerable<TodoItem>> Read();

        Task<TodoItem> Details(long? id);

        Task<TodoItem> Create(TodoItem todoItem);

        Task<TodoItem> Update(TodoItem todoItem);

        Task<long> Delete(long id);
    }
}