namespace PachiArmy.Scripts
{
    public class FoodFillStoreItem : StoreItem
    {
        public int FillAmount;

        public override bool CanPurchase()
        {
            if (!base.CanPurchase()) { return false; }

            return Inventory.FoodReserve < Inventory.MaxFoodReserve;
        }

        public override void TryPurchase()
        {
            if (!CanPurchase()) { return; }

            base.TryPurchase();

            if (Inventory.MaxFoodReserve - Inventory.FoodReserve < FillAmount)
            {
                Inventory.FoodReserve = Inventory.MaxFoodReserve;
            }
            else
            {
                Inventory.FoodReserve += FillAmount;
            }
        }
    }
}
