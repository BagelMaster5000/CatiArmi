namespace CatiArmi.Scripts
{
    public class Snack : InteractablePlaceable
    {
        public Position Position { get; set; }
        public string Test { get; set; }

        private const int INITIAL_DURABILITY = 5;
        private int durability;

        public Snack()
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

                AudioManager.PlaySound("snack-destroy");
            }
        }

        // Hover behavior
        public void Hovered()
        {
            AudioManager.PlaySound("object-hover");
        }

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
            if (durability > 0)
            {
                bool ate = invokerPachimari.EatSnack(0);
                if (ate)
                {
                    durability--;

                    invokerPachimari.SetState(Pachimari.PachiState.Eating);
                }
            }
        }
    }
}
