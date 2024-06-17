namespace PachiArmy.Scripts
{
    public class FoodBowlStoreItem : StoreItem
    {
        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            BoardManager.AddNewFoodBowl();
        }
    }
}
