﻿using Blazorise;
using PachiArmy.Scripts;

namespace PachiArmy.Pages
{
    public partial class HordeView
    {
        public HordeView()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    var pachi = new Pachimari();
            //    BoardManager.TryFindOpenSpaceAndPlacePlaceable(pachi);
            //}
            //var foodbowl = new FoodBowl();
            //BoardManager.TryFindOpenSpaceAndPlacePlaceable(foodbowl);
            //var waterBowl = new WaterBowl();
            //BoardManager.TryFindOpenSpaceAndPlacePlaceable(waterBowl);
            //var toy = new Toy();
            //BoardManager.TryFindOpenSpaceAndPlacePlaceable(toy);
            //var snack = new Snack();
            //BoardManager.TryFindOpenSpaceAndPlacePlaceable(snack);
        }

        private Task ObjectMoved(DraggableDroppedEventArgs<Placeable> movePlaceable)
        {
            var position = Scripts.Position.ParsePositionFromString(movePlaceable.DropZoneName);
            BoardManager.MovePlaceable(movePlaceable.Item, position);

            return Task.CompletedTask;
        }
    }
}