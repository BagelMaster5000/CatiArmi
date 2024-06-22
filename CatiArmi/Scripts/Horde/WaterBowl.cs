namespace CatiArmi.Scripts
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

            AudioManager.PlaySound("bowl-waterfill");
        }

        // Hover behavior
        public void Hovered()
        {
            AudioManager.PlaySound("object-hover");
        }

        public string GetHoverText()
        {
            return "<strong>Fill:</strong> " + water + "/" + GameManager.WaterBowlSize;
        }

        public string GetImage()
        {
            float fillPercentage = water * 1.0f / GameManager.WaterBowlSize;

            if (fillPercentage > 0.7f)
            {
                return "art/board/waterbowl-full.png";
            }
            else if (fillPercentage > 0f)
            {
                return "art/board/waterbowl-half.png";
            }
            else
            {
                return "art/board/waterbowl-empty.png";
            }
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

                    invokerPachimari.SetState(Pachimari.PachiState.Drinking);
                }
            }
        }
    }
}
