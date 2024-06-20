﻿namespace CatiArmi.Scripts
{
    public class FoodBowlStoreItem : StoreItem
    {
        public override bool TryPurchase()
        {
            if (BoardManager.IsBoardFull())
            {
                return false;
            }

            if (!base.TryPurchase()) { return false; }

            BoardManager.AddNewFoodBowl();

            return true;
        }
    }
}
