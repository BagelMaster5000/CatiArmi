namespace PachiArmy.Scripts
{
    public class WaterFillStoreItem : StoreItem
    {
        public uint FillAmount;

        public override bool CanPurchase()
        {
            if (!base.CanPurchase()) { return false; }

            return Inventory.WaterReserve < Inventory.MAX_WATER_RESERVE;
        }

        public override void TryPurchase()
        {
            if (!CanPurchase()) { return; }

            base.TryPurchase();

            if (Inventory.MAX_WATER_RESERVE - Inventory.WaterReserve < FillAmount)
            {
                Inventory.WaterReserve = Inventory.MAX_WATER_RESERVE;
            }
            else
            {
                Inventory.WaterReserve += FillAmount;
            }
        }
    }
}
