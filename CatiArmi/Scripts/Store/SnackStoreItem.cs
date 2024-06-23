namespace CatiArmi.Scripts
{
    public class SnackStoreItem : StoreItem
    {
        public int SnackType;

        public SnackStoreItem(int setSnackType)
        {
            SnackType = setSnackType;

            Icon = "art/board/snack-" + (SnackType + 1) + ".png";
        }

        public override bool TryPurchase()
        {
            if (BoardManager.IsBoardFull())
            {
                StoreManager.InvokeSpeechNoSpace();

                return false;
            }

            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewSnack(SnackType);

            return true;
        }
    }
}
