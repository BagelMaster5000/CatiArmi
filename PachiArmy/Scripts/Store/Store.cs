namespace CatiArmi.Scripts
{
    public class Store
    {
        public string Name;
        public string Icon;
        public int PachisToUnlock;
        public List<StoreItem> ItemsForSale;

        public bool TryBuy(StoreItem storeItem)
        {
            return false;
        }

        public bool IsShopAvailable()
        {
            return Inventory.GetTotalPachiCount() >= PachisToUnlock;
        }
    }
}
