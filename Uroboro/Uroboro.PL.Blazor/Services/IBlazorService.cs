using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uroboro.PL.Blazor.Models;

namespace Uroboro.PL.Blazor.Services
{
    interface IBlazorService
    {
        int Init();
        Task<int> InitAsync();
        Task<IReadOnlyList<TodoItem>> GetAsync();
    }
}
