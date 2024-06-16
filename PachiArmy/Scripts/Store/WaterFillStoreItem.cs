namespace PachiArmy.Scripts
{
    public class WaterFillStoreItem : StoreItem
    {
        public int FillAmount;

        public override bool TryPurchase()
        {
            bool success = base.TryPurchase();
            if (!success)
            {
                return false;
            }

            // Fill bowl
            return true;
        }
    }
}
