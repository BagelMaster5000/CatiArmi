namespace CatiArmi.Scripts
{
    public class FoodFillStoreItem : StoreItem
    {
        public int FillAmount;

        public override bool CanPurchase()
        {
            if (!base.CanPurchase()) { return false; }

            return Inventory.FoodReserve < Inventory.MaxFoodReserve;
        }

        public override bool TryPurchase()
        {
            if (!base.TryPurchase()) { return false; }

            if (Inventory.MaxFoodReserve - Inventory.FoodReserve < FillAmount)
            {
                Inventory.FoodReserve = Inventory.MaxFoodReserve;
            }
            else
            {
                Inventory.FoodReserve += FillAmount;
            }

            return true;
        }
    }
}
