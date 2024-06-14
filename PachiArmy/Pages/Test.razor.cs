using Microsoft.AspNetCore.Components;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    public partial class Test
    {
        [Parameter]
        public List<Placeable> Items { get; set; } = default!;

        [Parameter]
        public RenderFragment<Placeable> TestBody { get; set; } = default!;

        public void Refresh()
        {
            StateHasChanged();
        }
    }
}