using System.Net.NetworkInformation;

namespace CatiArmi.Scripts
{
    public class Snack : InteractablePlaceable
    {
        public Position Position { get; set; }

        private int durability;

        public int Variant = 0;

        public Snack()
        {
            durability = GameManager.SnackDurabilities[Variant];
        }

        public Snack(int setVariant)
        {
            durability = GameManager.SnackDurabilities[Variant];
            Variant = setVariant;
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
            string extraText = "";
            if (durability > 0)
            {
                extraText = "<br/>";
                switch (Variant)
                {
                    case 0:
                        extraText +=
                            "<span class='hotpanda-lightblue'>++Hunger</span><br/>" +
                            "<span class='hotpanda-lightblue'>+Happiness</span>";
                        break;
                    case 1:
                        extraText +=
                            "<span class='hotpanda-lightblue'>+Hunger</span><br/>" +
                            "<span class='hotpanda-lightblue'>+Happiness</span>";
                        break;
                    case 2:
                        extraText +=
                            "<span class='hotpanda-lightblue'>+Hunger</span><br/>" +
                            "<span class='hotpanda-lightyellow'>+Happiness</span>";
                        break;
                    case 3:
                        extraText +=
                            "<span class='hotpanda-lightyellow'>+Hunger</span><br/>" +
                            "<span class='hotpanda-lightyellow'>++Happiness</span>";
                        break;
                    case 4:
                        extraText +=
                            "<span class='hotpanda-lightyellow'>+++Hunger</span><br/>" +
                            "<span class='hotpanda-lightyellow'>++Happiness</span>";
                        break;
                    case 5:
                        extraText +=
                            "<span class='hotpanda-lightyellow'>+++Hunger</span><br/>" +
                            "<span class='hotpanda-lightyellow'>+++Happiness</span>";
                        break;
                }
            }

            return "<div style='text-align: center'>" +
                "<strong>Remaining:</strong> " + durability + extraText +
                "</div>";
        }

        public string GetImage()
        {
            if (durability > 0)
            {
                return "art/board/snack-" + (Variant + 1) + ".png";
            }
            else
            {
                return "art/board/finishedsnack.png";
            }
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
                bool ate = invokerPachimari.EatSnack(Variant);
                if (ate)
                {
                    durability--;

                    invokerPachimari.SetState(Pachimari.PachiState.Eating);
                }
            }
        }
    }
}
