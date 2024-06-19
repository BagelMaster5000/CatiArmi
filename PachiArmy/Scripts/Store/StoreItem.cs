﻿namespace PachiArmy.Scripts
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
            if (!CanPurchase())
            {
                AudioManager.PlaySound("item-failedtopurchase");

                return false;
            }

            Inventory.Money -= Price;

            if (LimitedItem)
            {
                OutOfStock = true;
            }

            AudioManager.PlaySound("item-purchased");

            return true;
        }
    }
}
