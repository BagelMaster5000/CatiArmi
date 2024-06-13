namespace PachiArmy.Scripts
{
    public class FoodBowl : PachiInteractablePlaceable
    {
        public GridPosition Position { get; set; }

        private const uint MAX_FOOD = 20;
        private uint food;

        public FoodBowl()
        {
            // TODO don't default this to 0,0
            Position = new GridPosition(0, 0);
        }

        // Click behavior
        public void Clicked()
        {
            Fill();
        }
        public void Fill()
        {

        }

        // Hover behavior
        public string GetHoverText()
        {
            throw new NotImplementedException();
        }

        public string GetImage()
        {
            throw new NotImplementedException();
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryEat(invokerPachimari);
        }
        public void TryEat(Pachimari invokerPachimari)
        {

        }

    }
}
