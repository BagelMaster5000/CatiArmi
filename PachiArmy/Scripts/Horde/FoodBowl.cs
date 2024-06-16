namespace PachiArmy.Scripts
{
    public class FoodBowl : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const uint MAX_FOOD = 50;
        private uint food;
        private const uint FILL_INCREMENT = 10;

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
            if (food == MAX_FOOD) { return; }
            else if (MAX_FOOD - food < FILL_INCREMENT)
            {
                uint remainingSpaceInBowl = MAX_FOOD - food;
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
                if (Inventory.FoodReserve >= FILL_INCREMENT)
                {
                    food += FILL_INCREMENT;
                    Inventory.FoodReserve -= FILL_INCREMENT;
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
            return "<strong>Fill:</strong> " + food + "/" + MAX_FOOD;
        }

        public string GetImage()
        {
            return "placeholders/foodbowl.png";
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryEat(invokerPachimari);
            Test = "<strong>Fill:</strong> " + food + "/" + MAX_FOOD;
        }
        public void TryEat(Pachimari invokerPachimari)
        {
            if (food > 0)
            {
                food--;
                invokerPachimari.Eat();
            }
        }
    }
}
