namespace PachiArmy.Scripts
{
    public class Toy : PachiInteractablePlaceable
    {
        public GridPosition Position { get; set; }

        private const uint INITIAL_DURABILITY = 30;
        private uint durability;

        public Toy()
        {
            // TODO don't default this to 0,0
            Position = new GridPosition(0, 0);
        }

        // Click behavior
        public void Clicked()
        {
            TryTrashBrokenToy();
        }
        public void TryTrashBrokenToy()
        {

        }

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
            TryPlay(invokerPachimari);
        }
        public void TryPlay(Pachimari invokerPachimari)
        {

        }
    }
}
