using Microsoft.AspNetCore.Components;

namespace Uroboro.PL.Blazor.Interfaces
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
