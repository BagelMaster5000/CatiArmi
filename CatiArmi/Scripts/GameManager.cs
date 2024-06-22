using System.Timers;

namespace CatiArmi.Scripts
{
    public static class GameManager
    {
        public static void InitializeTimers()
        {
            BoardManager.ClearForceBoardRefresh();
            BoardManager.ClearPachiTick();
            BoardManager.ClearBoardRefresh();
            Inventory.ClearResourcesUpdated();
        }

        // Balancing
        public static int PachisToWin = 100;

        public static int StartingMoney = 999;
        public static int MaxFoodReserve = 200;
        public static int StartingFoodReserve = 100;
        public static int MaxWaterReserve = 250;
        public static int StartingWaterReserve = 150;

        public static float TickTimeSeconds = 2;
        public static float RefreshTimeSeconds = 0.2f;

        public static int PachiExplosionPayoutMin = 10;
        public static int PachiExplosionPayoutMax = 20;
        public static int NumPachisPerExplosionMin = 2;
        public static int NumPachisPerExplosionMax = 3;
        public static int PachiIdleHappinessChangeOnTickFull = 20;
        public static int PachiIdleHappinessChangeOnTickNeutral = 20;
        public static int PachiIdleHappinessChangeOnTickNeedy = 20;
        public static int PachiIdleHappinessChangeOnTickDead = 20;
        public static int PachiIdleHungerChangeOnTick = -1;
        public static int PachiIdleThirstChangeOnTick = -1;
        public static int PachiEatingHungerChangeOnTick = 3;
        public static int PachiDrinkingThirstChangeOnTick = 3;
        public static List<int> PachiPlayingHappinessChangesOnTick = new List<int>() { 4, 5, 6 };
        public static List<int> PachiEatingSnackHungerChangesOnTick = new List<int>() { 6, 6, 7 };
        public static List<int> PachiEatingSnackHappinessChangesOnTick = new List<int>() { 1, 2, 3 };
        public static List<float> PachiHungerThresholds = new List<float>() { 0.8f, 0.5f, 0};
        public static List<float> PachiThirstThresholds = new List<float>() { 0.8f, 0.5f, 0};
        public static int PachiNumPetsToRevive = 3;
        public static int PachiHungerRestoreOnRevive = 20;
        public static int PachiThirstRestoreOnRevive = 20;
        public static int PachiNumPetsToIncrementHappiness = 10;

        public static int FoodBowlSize = 80;
        public static int FoodBowlFillAmount = 40;

        public static int WaterBowlSize = 80;
        public static int WaterBowlFillAmount = 40;

        public static List<int> SnackDurabilities = new List<int>() { 10, 15, 20 };

        public static List<int> ToyDurabilities = new List<int>() { 20, 25, 30 };

        public static int IdleMoneyTickInterval = 5;
        public static int IdleMoneyTickAmount = 2;
    }
}
