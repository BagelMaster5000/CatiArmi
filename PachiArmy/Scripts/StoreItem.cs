namespace PachiArmy.Scripts
{
    public abstract class StoreItem
    {
        public string Name;
        public string Icon;
        public uint Price;
        public bool LimitedItem;

        private bool disabled;

        public bool CanPurchase()
        {
            return false;
        }

        public virtual bool TryPurchase()
        {
            if (!CanPurchase())
            {
                return false;
            }

            if (LimitedItem)
            {
                disabled = true;
            }

            return true;
        }
    }
}
