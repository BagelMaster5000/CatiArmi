namespace PachiArmy.Scripts
{
    public class ToyStoreItem : StoreItem
    {
        public int ToyType;

        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            BoardManager.AddNewToy(ToyType);
        }
    }
}
