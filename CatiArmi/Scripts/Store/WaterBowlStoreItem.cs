namespace CatiArmi.Scripts
{
    public class WaterBowlStoreItem : StoreItem
    {
        public override bool TryPurchase()
        {
            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewWaterBowl();

            return true;
        }
    }
}
