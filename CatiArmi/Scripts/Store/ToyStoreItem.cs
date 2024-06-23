namespace CatiArmi.Scripts
{
    public class ToyStoreItem : StoreItem
    {
        public int ToyType;

        public ToyStoreItem(int setToyType)
        {
            ToyType = setToyType;

            Icon = "art/board/toy-" + (ToyType + 1) + ".png";
        }

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
