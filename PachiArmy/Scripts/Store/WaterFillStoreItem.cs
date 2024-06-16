namespace PachiArmy.Scripts
{
    public class WaterFillStoreItem : StoreItem
    {
        public uint FillAmount;

        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            Console.WriteLine("Purchased waterfill!");
            Inventory.WaterReserve += FillAmount;
        }
    }
}
