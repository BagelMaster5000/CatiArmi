using Blazorise;

namespace PachiArmy.Scripts
{
    public class FoodBowl : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const uint MAX_FOOD = 20;
        private uint food;

        public FoodBowl()
        {
            // TODO don't default this to 0,0
            Position = new Position(0, 0);

            food = MAX_FOOD;
        }

        // Click behavior
        public void Clicked()
        {
            Fill();
        }
        public void Fill()
        {
            food = MAX_FOOD;
        }

        // Hover behavior
        public string GetHoverText()
        {
            Test = "<strong>Fill:</strong> " + food + "/" + MAX_FOOD;
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
