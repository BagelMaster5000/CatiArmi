using System.Security.Cryptography;

namespace PachiArmy.Scripts
{
    public class Pachimari : Placeable
    {
        public Position Position { get; set; }

        enum PachiState
        {
            Idle,
            Eating,
            Drinking,
            Playing,
            Exhausted,
            Pet
        }
        private PachiState state;
        private bool readyToExplode;

        const uint HAPPINESS_THRESHOLD = 100;
        private uint happiness;

        const uint MAX_HUNGER = 100;
        private uint hunger;

        const uint MAX_THIRST = 100;
        private uint thirst;


        public Pachimari()
        {
            // TODO don't default this to 0,0. Find a random open spot on the board
            Position = new Position(0, 0);

            happiness = (uint)RandomNumberGenerator.GetInt32(100);
            hunger = (uint)RandomNumberGenerator.GetInt32(100);
            thirst = (uint)RandomNumberGenerator.GetInt32(100);
        }

        // Click behavior
        public void Clicked()
        {
            bool exploded = TryExplode();
            if (!exploded)
            {
                Pet();
            }
        }
        private bool TryExplode()
        {
            return false;
        }
        private void Explode()
        {

        }
        private void Pet()
        {

        }

        // Hover behavior
        public string GetHoverText()
        {
            uint happinessPercentage = happiness * 100 / HAPPINESS_THRESHOLD;
            string happinessTooltipText = happinessPercentage + "%";
            //if (happinessPercentage > 100)
            //{
            //    happinessTooltipText = "happinessTooltipText";
            //}

            float hungerPercentage = hunger * 1.0f / MAX_HUNGER;
            string hungerTooltipText;
            if (hungerPercentage > 0.8f)
            {
                hungerTooltipText = "<span class='hotpanda-lightblue'>Full! 😊</span>";
            }
            else if (hungerPercentage > 0.5f)
            {
                hungerTooltipText = "<span class='hotpanda-lightyellow'>Kinda... 😐</span>";
            }
            else if (hungerPercentage > 0.1f)
            {
                hungerTooltipText = "<span class='hotpanda-orange'>So hungry... 🥺</span>";
            }
            else
            {
                hungerTooltipText = "...";
            }

            float thirstPercentage = thirst * 1.0f / MAX_THIRST;
            string thirstTooltipText;
            if (thirstPercentage > 0.8f)
            {
                thirstTooltipText = "<span class='hotpanda-lightblue'>Full! 😊</span>";
            }
            else if (thirstPercentage > 0.5f)
            {
                thirstTooltipText = "<span class='hotpanda-lightyellow'>Kinda... 😐</span>";
            }
            else if (thirstPercentage > 0.1f)
            {
                thirstTooltipText = "<span class='hotpanda-orange'>So thirsty... 🥺</span>";
            }
            else
            {
                thirstTooltipText = "...";
            }

            return
                "<div style='text-align: center'>" +
                "<span class='hotpanda-lightyellow'><strong>Happiness</strong>: " + happinessTooltipText + "</span><br/>" +
                "<strong>Hungry?</strong> " + hungerTooltipText + "<br/>" +
                "<strong>Thirsty?</strong> " + thirstTooltipText + "" +
                "</div>";
        }


        public string GetImage()
        {
            switch (state)
            {
                case PachiState.Idle: return "placeholders/pachimari-idle.png";
                case PachiState.Eating: return "placeholders/pachimari-eating.png";
                case PachiState.Drinking: return "placeholders/pachimari-drinking.png";
                case PachiState.Playing: return "placeholders/pachimari-playing.png";
                case PachiState.Exhausted: return "placeholders/pachimari-exhausted.png";
                case PachiState.Pet: return "placeholders/pachimari-pet.png";
                default: return "placeholders/pachimari-idle.png";
            }
        }

        // Tick
        public void ProcessTick()
        {
            ProcessInteractions();
        }
        private void ProcessInteractions()
        {
            float hungerPercentage = hunger * 1.0f / MAX_HUNGER;
            float thirstPercentage = thirst * 1.0f / MAX_THIRST;
            if (hungerPercentage < 0.1f || thirstPercentage < 0.1f)
            {
                state = PachiState.Exhausted;
                return;
            }

            var interactablePlaceables = BoardManager.GetAllAdjacentInteractablePlaceables(Position.Row, Position.Col);
            foreach (var placeable in interactablePlaceables)
            {
                placeable.PachiInteract(this);
            }
        }

        public void Eat()
        {
            hunger += 2;
            happiness += 1;
        }
        public void Drink()
        {
            thirst += 2;
            happiness += 1;
        }
        public void Play()
        {
            happiness += 2;
        }
    }
}
