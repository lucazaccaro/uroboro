using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uroboro.Common.Models;
using Uroboro.PL.Blazor.Models;

namespace Uroboro.PL.Blazor.Services
{
    public class BlazorService : IBlazorService
    {
        public int Init()
        {
            Console.WriteLine("Init called");
            return 0;
        }

        public Task<int> InitAsync()
        {
            int result = 0;
            Console.WriteLine("InitAsync called");
            return Task.FromResult<int>(result);
        }

        public Task<IReadOnlyList<TodoItem>> GetAsync()
        {
            TodoItem item = new TodoItem() { IsComplete = true, Name = "Fake Item" };
            List<TodoItem> list = new List<TodoItem>() { item };
            IReadOnlyList<TodoItem> result = list.AsReadOnly();
            Console.WriteLine("GetAsync called");
            return Task.FromResult<IReadOnlyList<TodoItem>>(result);
        }
    }
}
