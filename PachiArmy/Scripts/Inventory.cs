using System.Timers;

namespace CatiArmi.Scripts
{
    public static class Inventory
    {
        public static int Money = GameManager.StartingMoney;

        public static int MaxFoodReserve = GameManager.MaxFoodReserve;
        public static int FoodReserve = GameManager.StartingFoodReserve;

        public static int MaxWaterReserve = GameManager.MaxWaterReserve;
        public static int WaterReserve = GameManager.StartingWaterReserve;

        public static int StoredPachis = 0;

        public static int GetTotalPachiCount()
        {
            return StoredPachis + BoardManager.GetAllActivePachis().Count;
        }

        public static Action ResourcesUpdated = delegate { };
        public static void InvokeResourcesUpdated() => ResourcesUpdated?.Invoke();
        public static void ClearResourcesUpdated() => ResourcesUpdated = null;

        private static int _moneyTicker = GameManager.IdleMoneyTickInterval;
        public static void IdleMoneyGain(Object source, ElapsedEventArgs e)
        {
            _moneyTicker--;
            if (_moneyTicker <= 0)
            {
                _moneyTicker = GameManager.IdleMoneyTickInterval;
                Money += GameManager.IdleMoneyTickAmount;
                InvokeResourcesUpdated();
            }
        }
    }
}
