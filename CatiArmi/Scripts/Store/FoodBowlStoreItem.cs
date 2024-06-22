namespace CatiArmi.Scripts
{
    public class FoodBowlStoreItem : StoreItem
    {
        public override bool TryPurchase()
        {
            if (BoardManager.IsBoardFull())
            {
                StoreManager.InvokeSpeechNoSpace();

                return false;
            }

            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewFoodBowl();

            return true;
        }
    }
}
