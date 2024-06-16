namespace PachiArmy.Scripts
{
    public class WaterBowl : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const uint MAX_WATER = 50;
        private uint water;
        private const uint FILL_INCREMENT = 10;

        public WaterBowl()
        {
            water = 0;
        }

        // Click behavior
        public void Clicked()
        {
            Fill();
        }
        public void Fill()
        {
            if (water == MAX_WATER) { return; }
            else if (MAX_WATER - water < FILL_INCREMENT)
            {
                uint remainingSpaceInBowl = MAX_WATER - water;
                if (Inventory.WaterReserve >= remainingSpaceInBowl)
                {
                    water += remainingSpaceInBowl;
                    Inventory.WaterReserve -= remainingSpaceInBowl;
                }
                else
                {
                    water += Inventory.WaterReserve;
                    Inventory.WaterReserve = 0;
                }
            }
            else
            {
                if (Inventory.WaterReserve >= FILL_INCREMENT)
                {
                    water += FILL_INCREMENT;
                    Inventory.WaterReserve -= FILL_INCREMENT;
                }
                else
                {
                    water += Inventory.WaterReserve;
                    Inventory.WaterReserve = 0;
                }
            }

            Inventory.InvokeResourcesUpdated();
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
