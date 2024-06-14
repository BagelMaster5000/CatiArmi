namespace PachiArmy.Scripts
{
    public class WaterBowl : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const uint MAX_WATER = 20;
        private uint water;

        public WaterBowl()
        {
            // TODO don't default this to 0,0
            Position = new Position(0, 0);

            water = MAX_WATER;
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
            return "<strong>Fill:</strong> " + water + "/" + MAX_WATER;
        }

        public string GetImage()
        {
            return "placeholders/waterbowl.png";
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryDrink(invokerPachimari);
        }
        public void TryDrink(Pachimari invokerPachimari)
        {
            if (water > 0)
            {
                water--;
                invokerPachimari.Drink();
            }
        }
    }
}
