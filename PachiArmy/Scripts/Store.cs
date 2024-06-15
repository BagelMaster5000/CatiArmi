namespace PachiArmy.Scripts
{
    public class Store
    {
        public string Name;
        public List<StoreItem> ItemsForSale;

        public bool TryBuy(StoreItem storeItem)
        {
            return false;
        }
    }
}
