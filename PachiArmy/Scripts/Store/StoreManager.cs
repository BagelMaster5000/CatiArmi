﻿namespace PachiArmy.Scripts
{
    public static class StoreManager
    {
        public static Store CurStore;
        public static List<Store> Stores;

        public static void Setup()
        {
            Stores = new List<Store>()
            {
                new Store()
                {
                    Name = "Placeholder's Pet Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 0,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new PlaceableStoreItem { Placeable = new FoodBowl(), Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 1, LimitedItem = true },
                        new PlaceableStoreItem { Placeable = new WaterBowl(), Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 1, LimitedItem = true },
                        new FoodFillStoreItem { FillAmount = 30, Name = "30u Food Fill", Icon = "placeholders/pachimari-idle.png", Price = 1, LimitedItem = false },
                        new WaterFillStoreItem { FillAmount = 30, Name = "30u Water Fill", Icon = "placeholders/pachimari-idle.png", Price = 1, LimitedItem = false },
                        new PlaceableStoreItem { Placeable = new Snack(), Name = "Scooby Snack 1", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                    }
                },
                new Store()
                {
                    Name = "Placeholder's Candy Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 0,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new PlaceableStoreItem { Placeable = new FoodBowl(), Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 20, LimitedItem = true },
                        new PlaceableStoreItem { Placeable = new WaterBowl(), Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 20, LimitedItem = true },
                        new PlaceableStoreItem { Placeable = new Snack(), Name = "Scooby Snack 2", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new PlaceableStoreItem { Placeable = new Snack(), Name = "Scooby Snack 3", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new PlaceableStoreItem { Placeable = new Toy(), Name = "Toy 1", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                    }
                },
                new Store()
                {
                    Name = "Placeholder's Toy Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 0,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new PlaceableStoreItem { Placeable = new FoodBowl(), Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 50, LimitedItem = true },
                        new PlaceableStoreItem { Placeable = new WaterBowl(), Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 50, LimitedItem = true },
                        new PlaceableStoreItem { Placeable = new Toy(), Name = "Toy 2", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new PlaceableStoreItem { Placeable = new Toy(), Name = "Toy 3", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new PlaceableStoreItem { Placeable = new Pachimari(), Name = "Da golden pachi", Icon = "placeholders/pachimari-idle.png", Price = 999, LimitedItem = false },
                    }
                },
            };

            CurStore = Stores[0];
        }
    }
}