namespace CatiArmi.Scripts
{
    public class Toy : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const int INITIAL_DURABILITY = 30;
        private int durability;

        public Toy()
        {
            durability = INITIAL_DURABILITY;
        }

        // Click behavior
        public void Clicked() => TryTrash();
        public void TryTrash()
        {
            if (durability == 0)
            {
                BoardManager.RemovePlaceable(this);
                
                AudioManager.PlaySound("toy-destroy");
            }
        }

        // Hover behavior
        public void Hovered()
        {
            AudioManager.PlaySound("object-hover");
        }

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
                bool played = invokerPachimari.Play(0);
                if (played)
                {
                    durability--;

                    invokerPachimari.SetState(Pachimari.PachiState.Playing);
                }
            }
        }
    }
}
