using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        const int HAPPINESS_THRESHOLD = 100;
        public int happiness;

        const int MAX_HUNGER = 100;
        private int hunger;

        const int MAX_THIRST = 100;
        private int thirst;

        public bool ConnectedToTickTimer = false;

        public Pachimari()
        {
            happiness = (int)RandomNumberGenerator.GetInt32(5, 10);
            hunger = (int)RandomNumberGenerator.GetInt32(60, 90);
            thirst = (int)RandomNumberGenerator.GetInt32(60, 90);
        }

        // Click behavior
        public void Clicked()
        {
            bool exploded = TryExplode();
            if (exploded)
            {
                return;
            }

            Pet();
        }
        private bool TryExplode()
        {
            if (happiness < HAPPINESS_THRESHOLD) { return false; }

            Explode();
            Inventory.Money += GameManager.PachiExplosionPayout;

            return true;
        }
        private void Explode()
        {
            BoardManager.RemovePlaceable(this);
            for (int i = 0; i < GameManager.NumPachisPerExplosion; i++)
            {
                BoardManager.AddNewPachimari();
            }
        }
        private void Pet()
        {
            // Maybe every 10 pets, happiness increments?
            //happiness++;
        }

        // Hover behavior
        public string GetHoverText()
        {
            int happinessPercentage = happiness * 100 / HAPPINESS_THRESHOLD;
            string happinessTooltipText = happinessPercentage + "%";
            //if (happinessPercentage > 100)
            //{
            //    happinessTooltipText = "happinessTooltipText";
            //}

            float hungerPercentage = hunger * 1.0f / MAX_HUNGER;
            int roundedHungerPercentage = (int)Math.Round(hungerPercentage * 100, 0);
            string hungerTooltipText;
            if (hungerPercentage > 0.85f)
            {
                hungerTooltipText = "<span class='hotpanda-lightblue'>" + roundedHungerPercentage + "% Full! 😊</span>";
            }
            else if (hungerPercentage > 0.5f)
            {
                hungerTooltipText = "<span class='hotpanda-lightyellow'>" + roundedHungerPercentage + "% Kinda... 😐</span>";
            }
            else if (hungerPercentage > 0.1f)
            {
                hungerTooltipText = "<span class='hotpanda-orange'>" + roundedHungerPercentage + "% So hungry... 🥺</span>";
            }
            else
            {
                hungerTooltipText = "...";
            }

            float thirstPercentage = thirst * 1.0f / MAX_THIRST;
            int roundedThirstPercentage = (int)Math.Round(thirstPercentage * 100, 0);
            string thirstTooltipText;
            if (thirstPercentage > 0.85f)
            {
                thirstTooltipText = "<span class='hotpanda-lightblue'>" + roundedThirstPercentage + "% Full! 😊</span>";
            }
            else if (thirstPercentage > 0.5f)
            {
                thirstTooltipText = "<span class='hotpanda-lightyellow'>" + roundedThirstPercentage + "% Kinda... 😐</span>";
            }
            else if (thirstPercentage > 0.1f)
            {
                thirstTooltipText = "<span class='hotpanda-orange'>" + roundedThirstPercentage + "% So thirsty... 🥺</span>";
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
            float hungerPercentage = hunger * 1.0f / MAX_HUNGER;
            float thirstPercentage = thirst * 1.0f / MAX_THIRST;
            if (thirstPercentage > 0.8f && hungerPercentage > 0.8f)
            {
                happiness += GameManager.PachiIdleHappinessChangeOnTickFull;
            }
            else if (thirstPercentage > 0.5f && hungerPercentage > 0.5f)
            {
                happiness += GameManager.PachiIdleHappinessChangeOnTickNeutral;
            }
            else
            {
                happiness += GameManager.PachiIdleHappinessChangeOnTickNeedy;
            }

            hunger += GameManager.PachiIdleHungerChangeOnTick;

            thirst += GameManager.PachiIdleThirstChangeOnTick;

            ProcessInteractions();

            happiness = Math.Clamp(happiness, 0, int.MaxValue);
            hunger = Math.Clamp(hunger, 0, int.MaxValue);
            thirst = Math.Clamp(thirst, 0, int.MaxValue);
        }
        private void ProcessInteractions()
        {
            if (hunger <= 0 || thirst <= 0)
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

        public bool Eat()
        {
            if (hunger >= MAX_HUNGER) { return false; }

            hunger += GameManager.PachiEatingHungerChangeOnTick;
            return true;
        }
        public bool EatSnack(int snackType)
        {
            if (hunger >= MAX_HUNGER) { return false; }

            hunger += GameManager.PachiEatingSnackHungerChangesOnTick.ElementAt(snackType);
            happiness += GameManager.PachiEatingSnackHappinessChangesOnTick.ElementAt(snackType);
            return true;
        }
        public bool Drink()
        {
            if (thirst >= MAX_THIRST) { return false; }

            thirst += GameManager.PachiDrinkingThirstChangeOnTick;
            return true;
        }
        public bool Play(int toyType)
        {
            happiness += GameManager.PachiPlayingHappinessChangesOnTick.ElementAt(toyType);
            return true;
        }
    }
}
