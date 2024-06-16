using Blazorise;
using PachiArmy.Scripts;
using Position = PachiArmy.Scripts.Position;

namespace PachiArmy.Pages
{
    public partial class HordeView
    {
        public List<Placeable> Placeables { get => BoardManager.GetAllActivePlaceables(); }

        public HordeView()
        {
        }

        private Task ObjectMoved(DraggableDroppedEventArgs<Placeable> movePlaceable)
        {
            var position = Position.ParsePositionFromString(movePlaceable.DropZoneName);
            BoardManager.MovePlaceable(movePlaceable.Item, position);

            return Task.CompletedTask;
        }
    }
}