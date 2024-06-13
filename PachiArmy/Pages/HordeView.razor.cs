using Blazorise;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    public partial class HordeView
    {
        public HordeView()
        {
            for (int i = 0; i < 10; i++)
            {
                var pachi = new Pachimari();
                BoardManager.TryFindOpenSpaceAndPlacePlaceable(pachi);
            }
        }

        private Task ObjectMoved(DraggableDroppedEventArgs<Placeable> movePlaceable)
        {
            var gridPosition = GridPosition.ParseGridPositionFromString(movePlaceable.DropZoneName);
            BoardManager.MovePlaceable(movePlaceable.Item, gridPosition);

            return Task.CompletedTask;
        }
    }
}
