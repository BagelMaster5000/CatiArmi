using System.Timers;

namespace PachiArmy.Scripts
{
    public static class Inventory
    {
        public static int Money = GameManager.StartingMoney;

        public static int MaxFoodReserve = GameManager.MaxFoodReserve;
        public static int FoodReserve = GameManager.StartingFoodReserve;

        public static int MaxWaterReserve = GameManager.MaxWaterReserve;
        public static int WaterReserve = GameManager.StartingWaterReserve;

        public static List<Pachimari> StoredPachis = new List<Pachimari>();

        public static int GetTotalPachiCount()
        {
            return StoredPachis.Count + BoardManager.GetAllActivePachis().Count;
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
