namespace PachiArmy.Scripts
{
    public class Store
    {
        public string Name;
        public string Icon;
        public uint PachisToUnlock;
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
