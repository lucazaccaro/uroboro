using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uroboro.Common.Models;
using Uroboro.PL.Blazor.Models;

namespace Uroboro.PL.Blazor.Services
{
    interface IBlazorService
    {
        static Dictionary<string, string> InMemoryDictionarySettings;
        int Init();
        Task<int> InitAsync();
        Task<IReadOnlyList<TodoItem>> GetAsync();
    }
}
