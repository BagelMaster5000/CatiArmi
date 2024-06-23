namespace CatiArmi.Scripts
{
    public class WaterFillStoreItem : StoreItem
    {
        public int FillAmount;

        public WaterFillStoreItem(int setFillAmount)
        {
            FillAmount = setFillAmount;

            Icon = "art/ui/water.png";
        }

        public override bool CanPurchase()
        {
            if (!base.CanPurchase()) { return false; }

            return Inventory.WaterReserve < Inventory.MaxWaterReserve;
        }

        public override bool TryPurchase()
        {
            if (Inventory.WaterReserve >= Inventory.MaxWaterReserve)
            {
                StoreManager.InvokeSpeechFullResource();
                return false;
            }

            if (!base.TryPurchase()) { return false; }

            if (Inventory.MaxWaterReserve - Inventory.WaterReserve < FillAmount)
            {
                Inventory.WaterReserve = Inventory.MaxWaterReserve;
            }
            else
            {
                Inventory.WaterReserve += FillAmount;
            }

            return true;
        }
    }
}
