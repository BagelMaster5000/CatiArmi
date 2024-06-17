namespace PachiArmy.Scripts
{
    public class WaterBowlStoreItem : StoreItem
    {
        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            BoardManager.AddNewWaterBowl();
        }
    }
}
