namespace PachiArmy.Scripts
{
    public class PlaceableStoreItem : StoreItem
    {
        public Placeable Placeable;

        public override void TryPurchase()
        {
            if (!CanPurchase())
            {
                return;
            }

            base.TryPurchase();

            Console.WriteLine("Purchased item!");
            BoardManager.TryFindOpenSpaceAndPlacePlaceable(Placeable);
        }
    }
}
