namespace CatiArmi.Scripts
{
    public class Toy : InteractablePlaceable
    {
        public Position Position { get; set; }

        private int durability;

        public int Variant;

        public Toy()
        {
            durability = GameManager.ToyDurabilities[Variant];
        }

        public Toy(int setVariant)
        {
            durability = GameManager.ToyDurabilities[Variant];
            Variant = setVariant;
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
            string extraText = "";
            if (durability > 0)
            {
                extraText = "<br/>";
                switch (Variant)
                {
                    case 0:
                        extraText +=
                            "<span class='hotpanda-lightblue'>+Happiness</span><br/>";
                        break;
                    case 1:
                        extraText +=
                            "<span class='hotpanda-lightyellow'>++Happiness</span><br/>";
                        break;
                    case 2:
                        extraText +=
                            "<span class='hotpanda-lightyellow'>+++Happiness</span><br/>";
                        break;
                }
            }

            return "<div style='text-align: center'>" +
                "<strong>Durability:</strong> " + durability + "/" + GameManager.ToyDurabilities[Variant] + extraText +
                "</div>";
        }

        public string GetImage()
        {
            if (durability > 0)
            {
                return "art/board/toy-" + (Variant + 1) + ".png";
            }
            else
            {
                return "art/board/brokentoy.png";
            }
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
                bool played = invokerPachimari.Play(Variant);
                if (played)
                {
                    durability--;

                    invokerPachimari.SetState(Pachimari.PachiState.Playing);
                }
            }
        }
    }
}
