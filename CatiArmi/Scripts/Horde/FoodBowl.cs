namespace CatiArmi.Scripts
{
    public class FoodBowl : InteractablePlaceable
    {
        public Position Position { get; set; }

        private int food;

        public FoodBowl()
        {
            food = 0;

            AudioManager.PlaySound("bowl-place");
        }

        // Click behavior
        public void Clicked()
        {
            Fill();
        }
        public void Fill()
        {
            if (food == GameManager.FoodBowlSize) { return; }
            else if (Inventory.FoodReserve == 0) { return; }
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

            AudioManager.PlaySound("bowl-foodfill");
        }

        // Hover behavior
        public void Hovered()
        {
            AudioManager.PlaySound("object-hover");
        }

        public string GetHoverText()
        {
            return "<strong>Fill:</strong> " + food + "/" + GameManager.FoodBowlSize;
        }

        public string GetImage()
        {
            float fillPercentage = food * 1.0f / GameManager.FoodBowlSize;

            if (fillPercentage > 0.7f)
            {
                return "art/board/foodbowl-full.png";
            }
            else if (fillPercentage > 0f)
            {
                return "art/board/foodbowl-half.png";
            }
            else
            {
                return "art/board/foodbowl-empty.png";
            }
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

                    invokerPachimari.SetState(Pachimari.PachiState.Eating);
                }
            }
        }
    }
}
