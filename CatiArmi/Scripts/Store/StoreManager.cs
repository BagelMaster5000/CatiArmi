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
                        new FoodBowlStoreItem { Name = "Food Bowl", Price = 25, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Price = 25, LimitedItem = true },
                        new FoodFillStoreItem(50) { Name = "50u Food Fill", Price = 5, LimitedItem = false },
                        new WaterFillStoreItem(50) { Name = "50u Water Fill", Price = 5, LimitedItem = false },
                        new SnackStoreItem(0) { Name = "Fish Snack", Price = 3, LimitedItem = false },
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
                        new FoodBowlStoreItem { Name = "Food Bowl", Price = 40, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Price = 40, LimitedItem = true },
                        new SnackStoreItem(1) { Name = "Kitty Pop", Price = 3, LimitedItem = false },
                        new SnackStoreItem(2) { Name = "Trippy Treat", Price = 3, LimitedItem = false },
                        new ToyStoreItem(0) { Name = "Teaser Toy", Price = 3, LimitedItem = false },
                        new SnackStoreItem(3) { Name = "Toe Beans", Price = 3, LimitedItem = false },
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
                        new FoodBowlStoreItem { Name = "Food Bowl", Price = 60, LimitedItem = true },
                        new WaterBowlStoreItem { Name = "Water Bowl", Price = 60, LimitedItem = true },
                        new ToyStoreItem(1) { Name = "Funny Mouse", Price = 3, LimitedItem = false },
                        new ToyStoreItem(2) { Name = "Yarn Ball", Price = 3, LimitedItem = false },
                        new SnackStoreItem(4) { Name = "Gravy Stix", Price = 3, LimitedItem = false },
                        new SnackStoreItem(5) { Name = "Soft Food Can", Price = 3, LimitedItem = false },
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
