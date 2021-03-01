using System.Collections.Generic;
using System.Threading.Tasks;
using Uroboro.Common.Models;

namespace Uroboro.PL.Blazor.Services
{
    interface IBlazorService
    {
        int Init();
        Task<int> InitAsync();
        Task<IReadOnlyList<TodoItem>> GetAsync();
    }
}
