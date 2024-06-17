namespace PachiArmy.Scripts
{
    public class SnackStoreItem : StoreItem
    {
        public int SnackType;

        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            BoardManager.AddNewSnack(SnackType);
        }
    }
}
