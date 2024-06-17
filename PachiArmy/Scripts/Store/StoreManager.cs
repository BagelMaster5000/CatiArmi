namespace PachiArmy.Scripts
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
                        new FoodBowlStoreItem { Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 25, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 25, LimitedItem = true },
                        new FoodFillStoreItem { FillAmount = 50, Name = "50u Food Fill", Icon = "placeholders/pachimari-idle.png", Price = 5, LimitedItem = false },
                        new WaterFillStoreItem { FillAmount = 50, Name = "50u Water Fill", Icon = "placeholders/pachimari-idle.png", Price = 5, LimitedItem = false },
                        new SnackStoreItem { SnackType = 0, Name = "Scooby Snack 1", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                    }
                },
                new Store()
                {
                    Name = "Placeholder's Candy Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 20,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new FoodBowlStoreItem { Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 40, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 40, LimitedItem = true },
                        new SnackStoreItem { SnackType = 1, Name = "Scooby Snack 2", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new SnackStoreItem { SnackType = 2, Name = "Scooby Snack 3", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new ToyStoreItem {ToyType = 0, Name = "Toy 1", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                    }
                },
                new Store()
                {
                    Name = "Placeholder's Toy Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 50,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new FoodBowlStoreItem { Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 60, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 60, LimitedItem = true },
                        new ToyStoreItem { ToyType = 1, Name = "Toy 2", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new ToyStoreItem { ToyType = 2, Name = "Toy 3", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        //new PlaceableStoreItem { Placeable = new Pachimari(), Name = "Da golden pachi", Icon = "placeholders/pachimari-idle.png", Price = 999, LimitedItem = false },
                    }
                },
            };

            CurStore = Stores[0];
        }
    }
}
