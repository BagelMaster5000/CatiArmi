using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CatiArmi.Scripts
{
    public class Pachimari : Placeable
    {
        public Position Position { get; set; }

        public enum PachiState
        {
            Idle,
            Eating,
            Drinking,
            Playing,
            Exhausted,
            Pet
        }
        private PachiState previousState = PachiState.Idle;
        public PachiState state = PachiState.Idle;

        const int HAPPINESS_THRESHOLD = 100;
        public int happiness;

        const int MAX_HUNGER = 100;
        private int hunger;

        const int MAX_THIRST = 100;
        private int thirst;

        private int numPetsToRevive = GameManager.PachiNumPetsToRevive;
        private int numRevives = 0;

        private int numPetsToIncrementHappiness = GameManager.PachiNumPetsToIncrementHappiness;

        public Pachimari()
        {
            happiness = RandomNumberGenerator.GetInt32(5, 10);
            hunger = RandomNumberGenerator.GetInt32(60, 90);
            thirst = RandomNumberGenerator.GetInt32(60, 90);
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
            Inventory.Money += RandomNumberGenerator.GetInt32(GameManager.PachiExplosionPayoutMin, GameManager.PachiExplosionPayoutMax);

            return true;
        }
        private void Explode()
        {
            BoardManager.RemovePlaceable(this);

            int numPachisToCreate = RandomNumberGenerator.GetInt32(GameManager.NumPachisPerExplosionMin, GameManager.NumPachisPerExplosionMax + 1);
            for (int i = 0; i < numPachisToCreate; i++)
            {
                BoardManager.AddNewPachimari();
            }

            AudioManager.PlaySound("pachi-explode");
            AudioManager.PlaySound("pachi-exploded");
        }
        private void Pet()
        {
            if (state == PachiState.Exhausted)
            {
                numPetsToRevive--;
                if (numPetsToRevive <= 0)
                {
                    numRevives++;
                    numPetsToRevive = GameManager.PachiNumPetsToRevive * (numRevives + 1);

                    state = PachiState.Idle;
                    hunger = GameManager.PachiHungerRestoreOnRevive;
                    thirst = GameManager.PachiThirstRestoreOnRevive;
                }
            }
            else
            {
                numPetsToIncrementHappiness--;
                if (numPetsToIncrementHappiness <= 0)
                {
                    numPetsToIncrementHappiness = GameManager.PachiNumPetsToIncrementHappiness;
                    happiness++;
                }
            }

            AudioManager.PlaySound("pachi-hover");
        }

        // Hover behavior
        public void Hovered()
        {
            AudioManager.PlaySound("pachi-hover");
        }

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
            if (hungerPercentage >= GameManager.PachiHungerThresholds[0])
            {
                hungerTooltipText = "<span class='hotpanda-lightblue'>" + roundedHungerPercentage + "% Full! 😊</span>";
            }
            else if (hungerPercentage >= GameManager.PachiHungerThresholds[1])
            {
                hungerTooltipText = "<span class='hotpanda-lightyellow'>" + roundedHungerPercentage + "% Kinda... 😐</span>";
            }
            else if (hungerPercentage >= GameManager.PachiHungerThresholds[2])
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
            if (thirstPercentage >= GameManager.PachiThirstThresholds[0])
            {
                thirstTooltipText = "<span class='hotpanda-lightblue'>" + roundedThirstPercentage + "% Full! 😊</span>";
            }
            else if (thirstPercentage >= GameManager.PachiThirstThresholds[1])
            {
                thirstTooltipText = "<span class='hotpanda-lightyellow'>" + roundedThirstPercentage + "% Kinda... 😐</span>";
            }
            else if (thirstPercentage >= GameManager.PachiThirstThresholds[2])
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
            if (thirstPercentage > GameManager.PachiThirstThresholds[0] && hungerPercentage > GameManager.PachiHungerThresholds[0])
            {
                happiness += GameManager.PachiIdleHappinessChangeOnTickFull;
            }
            else if (thirstPercentage > GameManager.PachiThirstThresholds[1] && hungerPercentage > GameManager.PachiHungerThresholds[1])
            {
                happiness += GameManager.PachiIdleHappinessChangeOnTickNeutral;
            }
            else if (thirstPercentage > GameManager.PachiThirstThresholds[2] && hungerPercentage > GameManager.PachiHungerThresholds[2])
            {
                happiness += GameManager.PachiIdleHappinessChangeOnTickNeedy;
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
            if (hunger <= GameManager.PachiThirstThresholds[2] || thirst <= GameManager.PachiHungerThresholds[2])
            {
                state = PachiState.Exhausted;
                return;
            }

            var interactablePlaceables = BoardManager.GetAllAdjacentInteractablePlaceables(Position.Row, Position.Col);
            state = PachiState.Idle;
            foreach (var placeable in interactablePlaceables)
            {
                placeable.PachiInteract(this);
            }

            switch (state)
            {
                case PachiState.Idle: AudioManager.PlaySound("pachi-idle"); break;
                case PachiState.Eating: AudioManager.PlaySound("pachi-eating"); break;
                case PachiState.Drinking: AudioManager.PlaySound("pachi-drinking"); break;
                case PachiState.Playing: AudioManager.PlaySound("pachi-playing"); break;
            }

            previousState = state;
        }
        public void SetState(PachiState setState)
        {
            if (state == PachiState.Idle || setState != previousState)
            {
                state = setState;
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
