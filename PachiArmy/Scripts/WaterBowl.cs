namespace PachiArmy.Scripts
{
    public class WaterBowl : PachiInteractablePlaceable
    {
        public GridPosition Position { get; set; }

        private const uint MAX_WATER = 20;
        private uint water;

        public WaterBowl()
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
            TryDrink(invokerPachimari);
        }
        public void TryDrink(Pachimari invokerPachimari)
        {

        }
    }
}
