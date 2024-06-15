using Blazorise;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    public partial class HordeView
    {
        public List<Placeable> Placeables = BoardManager.ActivePlaceables;

        public HordeView()
        {
        }

        private Task ObjectMoved(DraggableDroppedEventArgs<Placeable> movePlaceable)
        {
            var position = Scripts.Position.ParsePositionFromString(movePlaceable.DropZoneName);
            BoardManager.MovePlaceable(movePlaceable.Item, position);

            return Task.CompletedTask;
        }
    }
}