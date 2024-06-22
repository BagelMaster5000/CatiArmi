namespace CatiArmi.Scripts
{
    public class ToyStoreItem : StoreItem
    {
        public int ToyType;

        public override bool TryPurchase()
        {
            if (BoardManager.IsBoardFull())
            {
                StoreManager.InvokeSpeechNoSpace();

                return false;
            }

            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewToy(ToyType);

            return true;
        }
    }
}
