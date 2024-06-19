namespace PachiArmy.Scripts
{
    public class ToyStoreItem : StoreItem
    {
        public int ToyType;

        public override bool TryPurchase()
        {
            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewToy(ToyType);

            return true;
        }
    }
}
