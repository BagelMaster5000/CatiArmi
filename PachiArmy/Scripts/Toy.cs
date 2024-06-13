namespace PachiArmy.Scripts
{
    public class Toy : InteractablePlaceable
    {
        public Position Position { get; set; }

        private const uint INITIAL_DURABILITY = 30;
        private uint durability;

        public Toy()
        {
            // TODO don't default this to 0,0
            Position = new Position(0, 0);

            durability = INITIAL_DURABILITY;
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
            return "<strong>Durability:</strong> " + durability + "/" + INITIAL_DURABILITY;
        }

        public string GetImage()
        {
            return "placeholders/toy.png";
        }

        // Pachi interaction
        public void PachiInteract(Pachimari invokerPachimari)
        {
            TryPlay(invokerPachimari);
        }
        public void TryPlay(Pachimari invokerPachimari)
        {
            durability--;
            invokerPachimari.Play();

            if (durability <= 0)
            {
                // Destroy
            }
        }
    }
}
