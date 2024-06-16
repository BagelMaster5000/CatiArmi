namespace PachiArmy.Scripts
{
    public class Toy : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const uint INITIAL_DURABILITY = 30;
        private uint durability;

        public Toy()
        {
            durability = INITIAL_DURABILITY;
        }

        // Click behavior
        public void Clicked()
        {
            TryTrashBrokenToy();
        }
        public void TryTrashBrokenToy()
        {
            if (durability == 0)
            {
                BoardManager.RemovePlaceable(this);
            }
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
            if (durability > 0)
            {
                durability--;
                invokerPachimari.Play();
            }
        }
    }
}
