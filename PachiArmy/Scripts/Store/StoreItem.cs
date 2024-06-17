namespace PachiArmy.Scripts
{
    public abstract class StoreItem
    {
        public string Name;
        public string Icon;
        public uint Price;
        public bool LimitedItem;

        public bool OutOfStock;

        public virtual bool CanPurchase()
        {
            return !OutOfStock && Inventory.Money >= Price;
        }

        public virtual void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            Inventory.Money -= Price;

            if (LimitedItem)
            {
                OutOfStock = true;
            }
        }
    }
}
