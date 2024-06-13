using Blazorise;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    public partial class HordeView
    {
        //private List<Placeable> items { get; set; }

        public HordeView()
        {
            Console.WriteLine("Reached horde view constructor");
            for (int i = 0; i < 10; i++)
            {
                var pachi = new Pachimari();
                BoardManager.TryFindOpenSpaceAndPlacePlaceable(pachi);
            }
                //items = BoardManager.ActivePlaceables;
        }

        private Task ObjectMoved(DraggableDroppedEventArgs<Placeable> movePlaceable)
        {
            var gridPosition = GridPosition.ParseGridPositionFromString(movePlaceable.DropZoneName);
            BoardManager.MovePlaceable(movePlaceable.Item, gridPosition);
            //StateHasChanged();
            //movePlaceable.Item.Position = gridPosition;
            var pachi = new Pachimari();
            BoardManager.TryFindOpenSpaceAndPlacePlaceable(pachi);
            //items = BoardManager.ActivePlaceables;
            //dropItem.Item.Group = dropItem.DropZoneName;


            return Task.CompletedTask;
        }
    }
}
