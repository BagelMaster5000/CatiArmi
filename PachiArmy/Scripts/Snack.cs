namespace PachiArmy.Scripts
{
    public class Snack : InteractablePlaceable
    {
        public Position Position { get; set; }

        private const uint INITIAL_DURABILITY = 30;
        private uint durability;

        public Snack()
        {
            // TODO don't default this to 0,0
            Position = new Position(0, 0);

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
