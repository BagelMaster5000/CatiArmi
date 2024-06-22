namespace CatiArmi.Scripts
{
    public class WaterBowlStoreItem : StoreItem
    {
        public override bool TryPurchase()
        {
            if (BoardManager.IsBoardFull())
            {
                StoreManager.InvokeSpeechNoSpace();

                return false;
            }

            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewWaterBowl();

            return true;
        }
    }
}
