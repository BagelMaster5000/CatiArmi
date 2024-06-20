namespace CatiArmi.Scripts
{
    public class ToyStoreItem : StoreItem
    {
        public int ToyType;

        public override bool TryPurchase()
        {
            if (BoardManager.IsBoardFull())
            {
                return false;
            }

            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewToy(ToyType);

            return true;
        }
    }
}
