namespace PachiArmy.Scripts
{
    public class FoodBowl : InteractablePlaceable
    {
        public Position Position { get; set; }

        private int food;

        public FoodBowl()
        {
            food = 0;
        }

        // Click behavior
        public void Clicked()
        {
            Fill();
        }
        public void Fill()
        {
            if (food == GameManager.FoodBowlSize) { return; }
            else if (GameManager.FoodBowlSize - food < GameManager.FoodBowlFillAmount)
            {
                int remainingSpaceInBowl = GameManager.FoodBowlSize - food;
                if (Inventory.FoodReserve >= remainingSpaceInBowl)
                {
                    food += remainingSpaceInBowl;
                    Inventory.FoodReserve -= remainingSpaceInBowl;
                }
                else
                {
                    food += Inventory.FoodReserve;
                    Inventory.FoodReserve = 0;
                }
            }
            else
            {
                if (Inventory.FoodReserve >= GameManager.FoodBowlFillAmount)
                {
                    food += GameManager.FoodBowlFillAmount;
                    Inventory.FoodReserve -= GameManager.FoodBowlFillAmount;
                }
                else
                {
                    food += Inventory.FoodReserve;
                    Inventory.FoodReserve = 0;
                }
            }

            Inventory.InvokeResourcesUpdated();
        }

        // Hover behavior
        public string GetHoverText()
        {
            return "<strong>Fill:</strong> " + food + "/" + GameManager.FoodBowlSize;
        }

        public string GetImage()
        {
            return "placeholders/foodbowl.png";
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryEat(invokerPachimari);
        }
        public void TryEat(Pachimari invokerPachimari)
        {
            if (food > 0)
            {
                bool ate = invokerPachimari.Eat();
                if (ate)
                {
                    food--;
                }
            }
        }
    }
}
