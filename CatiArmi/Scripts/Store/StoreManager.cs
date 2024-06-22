using System.Security.Cryptography;

namespace CatiArmi.Scripts
{
    public static class StoreManager
    {
        public static Store CurStore;
        public static List<Store> Stores;

        public static Action StoreRefresh = delegate { };
        public static void InvokeStoreRefresh() => StoreRefresh?.Invoke();
        public static void ClearStoreRefresh() => StoreRefresh = null;

        public enum DialogState
        {
            Greeting,
            Purchased,
            CantAfford,
            FullResource,
            NoSpace,
        };
        public static DialogState CurDialogState = DialogState.Greeting;

        public static void Setup()
        {
            Stores = new List<Store>()
            {
                new Store()
                {
                    Name = "Placeholder's Pet Store",
                    DisplayName = "Pet Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 0,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new FoodBowlStoreItem { Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 25, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 25, LimitedItem = true },
                        new FoodFillStoreItem { FillAmount = 50, Name = "50u Food Fill", Icon = "placeholders/pachimari-idle.png", Price = 5, LimitedItem = false },
                        new WaterFillStoreItem { FillAmount = 50, Name = "50u Water Fill", Icon = "placeholders/pachimari-idle.png", Price = 5, LimitedItem = false },
                        new SnackStoreItem { SnackType = 0, Name = "Scooby Snack 1", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                    },
                    SpeechGreetings = new List<string>()
                    {
                        "Greetings1",
                        "Greetings2",
                        "Greetings3",
                    },
                    SpeechPurchased = new List<string>()
                    {
                        "Purchased1",
                        "Purchased2",
                        "Purchased3",
                    },
                    SpeechCantAfford = new List<string>()
                    {
                        "Can'tAfford1",
                        "Can'tAfford2",
                        "Can'tAfford3",
                    },
                    SpeechFullResource = new List<string>()
                    {
                        "FullResource1",
                        "FullResource2",
                        "FullResource3",
                    },
                    SpeechNoSpace = new List<string>()
                    {
                        "NoSpace1",
                        "NoSpace2",
                        "NoSpace3",
                    },
                },
                new Store()
                {
                    Name = "Placeholder's Candy Store",
                    DisplayName = "Candy Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 20,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new FoodBowlStoreItem { Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 40, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 40, LimitedItem = true },
                        new SnackStoreItem { SnackType = 1, Name = "Scooby Snack 2", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new SnackStoreItem { SnackType = 2, Name = "Scooby Snack 3", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new ToyStoreItem {ToyType = 0, Name = "Toy 1", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                    },
                    SpeechGreetings = new List<string>()
                    {
                        "Greetings1",
                        "Greetings2",
                        "Greetings3",
                    },
                    SpeechPurchased = new List<string>()
                    {
                        "Purchased1",
                        "Purchased2",
                        "Purchased3",
                    },
                    SpeechCantAfford = new List<string>()
                    {
                        "Can'tAfford1",
                        "Can'tAfford2",
                        "Can'tAfford3",
                    },
                    SpeechFullResource = new List<string>()
                    {
                        "FullResource1",
                        "FullResource2",
                        "FullResource3",
                    },
                    SpeechNoSpace = new List<string>()
                    {
                        "NoSpace1",
                        "NoSpace2",
                        "NoSpace3",
                    },
                },
                new Store()
                {
                    Name = "Placeholder's Toy Store",
                    DisplayName = "Toy Store",
                    Icon = "placeholders/pachimari-idle.png",
                    PachisToUnlock = 50,
                    ItemsForSale = new List<StoreItem>()
                    {
                        new FoodBowlStoreItem { Name = "Food Bowl", Icon = "placeholders/pachimari-idle.png", Price = 60, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Icon = "placeholders/pachimari-idle.png", Price = 60, LimitedItem = true },
                        new ToyStoreItem { ToyType = 1, Name = "Toy 2", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        new ToyStoreItem { ToyType = 2, Name = "Toy 3", Icon = "placeholders/pachimari-idle.png", Price = 3, LimitedItem = false },
                        //new PlaceableStoreItem { Placeable = new Pachimari(), Name = "Da golden pachi", Icon = "placeholders/pachimari-idle.png", Price = 999, LimitedItem = false },
                    },
                    SpeechGreetings = new List<string>()
                    {
                        "Greetings1",
                        "Greetings2",
                        "Greetings3",
                    },
                    SpeechPurchased = new List<string>()
                    {
                        "Purchased1",
                        "Purchased2",
                        "Purchased3",
                    },
                    SpeechCantAfford = new List<string>()
                    {
                        "Can'tAfford1",
                        "Can'tAfford2",
                        "Can'tAfford3",
                    },
                    SpeechFullResource = new List<string>()
                    {
                        "FullResource1",
                        "FullResource2",
                        "FullResource3",
                    },
                    SpeechNoSpace = new List<string>()
                    {
                        "NoSpace1",
                        "NoSpace2",
                        "NoSpace3",
                    },
                },
            };

            CurStore = Stores[0];
        }

        public static void InvokeSpeechEnteredStore()
        {
            CurStore.CurSpeech = CurStore.SpeechGreetings[RandomNumberGenerator.GetInt32(0, CurStore.SpeechGreetings.Count)];
            CurDialogState = DialogState.Greeting;

            InvokeStoreRefresh();
        }

        public static void InvokeSpeechPurchased()
        {
            if (CurDialogState != DialogState.Purchased)
            {
                CurStore.CurSpeech = CurStore.SpeechPurchased[RandomNumberGenerator.GetInt32(0, CurStore.SpeechPurchased.Count)];
                CurDialogState = DialogState.Purchased;
            }

            InvokeStoreRefresh();
        }

        public static void InvokeSpeechCouldntAfford()
        {
            if (CurDialogState != DialogState.CantAfford)
            {
                CurStore.CurSpeech = CurStore.SpeechCantAfford[RandomNumberGenerator.GetInt32(0, CurStore.SpeechCantAfford.Count)];
                CurDialogState = DialogState.CantAfford;
            }

            InvokeStoreRefresh();
        }

        public static void InvokeSpeechFullResource()
        {
            if (CurDialogState != DialogState.FullResource)
            {
                CurStore.CurSpeech = CurStore.SpeechFullResource[RandomNumberGenerator.GetInt32(0, CurStore.SpeechFullResource.Count)];
                CurDialogState = DialogState.FullResource;
            }

            InvokeStoreRefresh();
        }

        public static void InvokeSpeechNoSpace()
            {
                if (CurDialogState != DialogState.NoSpace)
                {
                    CurStore.CurSpeech = CurStore.SpeechNoSpace[RandomNumberGenerator.GetInt32(0, CurStore.SpeechNoSpace.Count)];
                    CurDialogState = DialogState.NoSpace;
                }

            InvokeStoreRefresh();
        }
    }
}
