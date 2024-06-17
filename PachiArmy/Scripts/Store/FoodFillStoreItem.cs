namespace PachiArmy.Scripts
{
    public class FoodFillStoreItem : StoreItem
    {
        public uint FillAmount;

        public override bool CanPurchase()
        {
            if (!base.CanPurchase()) { return false; }

            return Inventory.FoodReserve < Inventory.MAX_FOOD_RESERVE;
        }

        public override void TryPurchase()
        {
            if (!CanPurchase()) { return; }

            base.TryPurchase();

            if (Inventory.MAX_FOOD_RESERVE - Inventory.FoodReserve < FillAmount)
            {
                Inventory.FoodReserve = Inventory.MAX_FOOD_RESERVE;
            }
            else
            {
                Inventory.FoodReserve += FillAmount;
            }
        }
    }
}
