namespace CatiArmi.Scripts
{
    public class SnackStoreItem : StoreItem
    {
        public int SnackType;

        public override bool TryPurchase()
        {
            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewSnack(SnackType);

            return true;
        }
    }
}
