namespace PachiArmy.Scripts
{
    public class WaterBowl : InteractablePlaceable
    {
        public Position Position { get; set; }

        private int water;

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
            if (water == GameManager.WaterBowlSize) { return; }
            else if (GameManager.WaterBowlSize - water < GameManager.WaterBowlFillAmount)
            {
                int remainingSpaceInBowl = GameManager.WaterBowlSize - water;
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
                if (Inventory.WaterReserve >= GameManager.WaterBowlFillAmount)
                {
                    water += GameManager.WaterBowlFillAmount;
                    Inventory.WaterReserve -= GameManager.WaterBowlFillAmount;
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
            return "<strong>Fill:</strong> " + water + "/" + GameManager.WaterBowlSize;
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
                bool drank = invokerPachimari.Drink();
                if (drank)
                {
                    water--;
                }
            }
        }
    }
}
