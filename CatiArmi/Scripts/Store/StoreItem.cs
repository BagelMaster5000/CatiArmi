namespace CatiArmi.Scripts
{
    public abstract class StoreItem
    {
        public string Name;
        public string Icon;
        public int Price;
        public bool LimitedItem;

        public bool OutOfStock;

        public virtual bool CanPurchase()
        {
            return !OutOfStock && Inventory.Money >= Price;
        }

        public virtual bool TryPurchase()
        {
            if (OutOfStock)
            {
                StoreManager.InvokeSpeechSoldOut();

                AudioManager.PlaySound("item-failedtopurchase");

                return false;
            }

            if (Inventory.Money < Price)
            {
                StoreManager.InvokeSpeechCouldntAfford();

                AudioManager.PlaySound("item-failedtopurchase");

                return false;
            }

            Inventory.Money -= Price;

            if (LimitedItem)
            {
                OutOfStock = true;
            }

            StoreManager.InvokeSpeechPurchased();

            AudioManager.PlaySound("item-purchased");

            return true;
        }
    }
}
