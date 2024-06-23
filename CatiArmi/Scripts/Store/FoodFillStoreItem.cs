namespace CatiArmi.Scripts
{
    public class FoodFillStoreItem : StoreItem
    {
        public int FillAmount;

        public FoodFillStoreItem(int setFillAmount)
        {
            FillAmount = setFillAmount;

            Icon = "art/ui/food.png";
        }

        public override bool CanPurchase()
        {
            if (!base.CanPurchase()) { return false; }

            return Inventory.FoodReserve < Inventory.MaxFoodReserve;
        }

        public override bool TryPurchase()
        {
            if (Inventory.FoodReserve >= Inventory.MaxFoodReserve)
            {
                StoreManager.InvokeSpeechFullResource();

                AudioManager.PlaySound("item-failedtopurchase");

                return false;
            }

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
