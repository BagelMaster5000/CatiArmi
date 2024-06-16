namespace PachiArmy.Scripts
{
    public class FoodFillStoreItem : StoreItem
    {
        public uint FillAmount;

        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            Console.WriteLine("Purchased foodfill!");
            Inventory.FoodReserve += FillAmount;
        }
    }
}
