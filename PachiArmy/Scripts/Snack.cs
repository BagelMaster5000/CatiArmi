namespace PachiArmy.Scripts
{
    public class Snack : PachiInteractablePlaceable
    {
        public GridPosition Position { get; set; }

        private const uint INITIAL_DURABILITY = 30;
        private uint durability;

        public Snack()
        {
            // TODO don't default this to 0,0
            Position = new GridPosition(0, 0);
        }

        // Click behavior
        public void Clicked() { }

        // Hover behavior
        public string GetHoverText()
        {
            throw new NotImplementedException();
        }

        public string GetImage()
        {
            throw new NotImplementedException();
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryEat(invokerPachimari);
        }
        public void TryEat(Pachimari invokerPachimari)
        {

        }
    }
}
