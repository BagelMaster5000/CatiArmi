namespace PachiArmy.Scripts
{
    public static class Inventory
    {
        public static uint Money = 8;

        public const uint MAX_FOOD_RESERVE = 100;
        public static uint FoodReserve = 0;

        public const uint MAX_WATER_RESERVE = 100;
        public static uint WaterReserve = 0;

        public static List<Pachimari> StoredPachis = new List<Pachimari>();

        public static int GetTotalPachiCount()
        {
            return StoredPachis.Count + BoardManager.GetAllActivePachis().Count;
        }

        public static Action ResourcesUpdated = delegate { };
        public static void InvokeResourcesUpdated() => ResourcesUpdated?.Invoke();
        public static void ClearResourcesUpdated() => ResourcesUpdated = null;
    }
}
