using Blazorise;
using Microsoft.AspNetCore.Components;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    public partial class HordeView
    {
        [Parameter]
        public List<Placeable> Items { get; set; } = default!;

        [Parameter]
        public RenderFragment<Placeable> TestBody { get; set; } = default!;

        public void Refresh()
        {
            StateHasChanged();
        }

        private Task ObjectMoved(DraggableDroppedEventArgs<Placeable> movePlaceable)
        {
            var position = Scripts.Position.ParsePositionFromString(movePlaceable.DropZoneName);
            BoardManager.MovePlaceable(movePlaceable.Item, position);

            return Task.CompletedTask;
        }
    }
}