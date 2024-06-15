namespace PachiArmy.Scripts
{
    public class PlaceableStoreItem : StoreItem
    {
        public Placeable Placeable;

        public override bool TryPurchase()
        {
            bool success = base.TryPurchase();
            if (!success)
            {
                return false;
            }

            BoardManager.TryFindOpenSpaceAndPlacePlaceable(Placeable);
            return true;
        }
    }
}
