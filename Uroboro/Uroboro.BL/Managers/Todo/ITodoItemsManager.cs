using System.Collections.Generic;
using System.Threading.Tasks;
using Uroboro.Common.Models;

namespace Uroboro.BL.Managers.Todo
{
    public interface ITodoItemsManager
    {
        Task<IEnumerable<TodoItem>> Read();

        Task<TodoItem> Details(long? id);

        Task<TodoItem> Create(TodoItem todoItem);

        Task<TodoItem> Update(TodoItem todoItem);

        Task<long?> Delete(long id);
    }
}