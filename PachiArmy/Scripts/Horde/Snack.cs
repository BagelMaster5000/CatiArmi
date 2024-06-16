namespace PachiArmy.Scripts
{
    public class Snack : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const uint INITIAL_DURABILITY = 30;
        private uint durability;

        public Snack()
        {
            durability = INITIAL_DURABILITY;
        }

        // Click behavior
        public void Clicked() { }

        // Hover behavior
        public string GetHoverText()
        {
            return "<strong>Remaining:</strong> " + durability;
        }

        public string GetImage()
        {
            return "placeholders/snack.png";
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryEat(invokerPachimari);
        }
        public void TryEat(Pachimari invokerPachimari)
        {
            durability--;
            invokerPachimari.Eat();

            if (durability <= 0)
            {
                // Destroy
            }
        }
    }
}
