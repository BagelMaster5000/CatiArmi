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
            Soldout,
            CantAfford,
            FullFood,
            FullWater,
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
                        new FoodFillStoreItem(50) { Name = "Food Fill", Price = 5, LimitedItem = false },
                        new WaterFillStoreItem(50) { Name = "Water Fill", Price = 5, LimitedItem = false },
                        new SnackStoreItem(0) { Name = "Fish Snack", Price = 3, LimitedItem = false },
                    },
                    SpeechGreetings = new List<string>()
                    {
                        "Oh hello! Almost didn’t see you there!",
                        "You look like the compassionate type… er… I think…",
                        "You look like a nice guy! Or gal… I need new glasses…",
                    },
                    SpeechPurchased = new List<string>()
                    {
                        "You would never use all these finite resources for evil... right?",
                        "I trust you to make the right decision…",
                        "With great resources, comes great responsibility!",
                    },
                    SpeechSoldOut = new List<string>()
                    {
                        "SoldOut1",
                    },
                    SpeechCantAfford = new List<string>()
                    {
                        "I can’t operate this place without any coin!",
                        "I would give handouts… if I could afford to…",
                        "I would just give you this for free but, inflation you know?",
                    },
                    SpeechFullFood = new List<string>()
                    {
                        "I don’t think I can pour any more food into that container, it’ll overflow!",
                    },
                    SpeechFullWater = new List<string>()
                    {
                        "I can’t pour any more water into that container, it’ll overflow!",
                    },
                    SpeechNoSpace = new List<string>()
                    {
                        "Oh shoot! Looks like you’re out of space.",
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
                        new SnackStoreItem(1) { Name = "Kitty Pop", Price = 6, LimitedItem = false },
                        new SnackStoreItem(2) { Name = "Trippy Treat", Price = 7, LimitedItem = false },
                        new ToyStoreItem(0) { Name = "Teaser Toy", Price = 10, LimitedItem = false },
                        new SnackStoreItem(3) { Name = "Toe Beans", Price = 8, LimitedItem = false },
                    },
                    SpeechGreetings = new List<string>()
                    {
                        "On candy stripe legs… softly through the shadow… stealing past the windows… looking for the victim… shhh…. OH! Haha, I didn’t see you there.",
                        "Excuse me, I’m looking for customers with extravagant taste, have you seen any around?",
                        "I can refuse service to anyone who doesn’t look rich enough to shop here, but I’ll make an exception for you~",
                    },
                    SpeechPurchased = new List<string>()
                    {
                        "Bring me a bit more coin next time, I’ll throw in something sweet. <3",
                        "Commision more sophisticated confectionaries next time, I’m a very busy bee.",
                        "You should bee less frugal next time.",
                    },
                    SpeechSoldOut = new List<string>()
                    {
                        "SoldOut1",
                    },
                    SpeechCantAfford = new List<string>()
                    {
                        "You can’t afford that, honey~",
                        "You look a little light on coin for my taste.",
                        "My sweets are a bit more… refined.",
                    },
                    SpeechFullFood = new List<string>()
                    {
                        "FullFood1",
                    },
                    SpeechFullWater = new List<string>()
                    {
                        "FullWater1",
                    },
                    SpeechNoSpace = new List<string>()
                    {
                        "Perhaps investing in a bit more space would suit you.",
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
                        new ToyStoreItem(1) { Name = "Yarn Ball", Price = 20, LimitedItem = false },
                        new ToyStoreItem(2) { Name = "Funny Mouse", Price = 25, LimitedItem = false },
                        new SnackStoreItem(4) { Name = "Gravy Stix", Price = 10, LimitedItem = false },
                        new SnackStoreItem(5) { Name = "Soft Food Can", Price = 15, LimitedItem = false },
                        //new PlaceableStoreItem { Placeable = new Pachimari(), Name = "Da golden pachi", Icon = "placeholders/pachimari-idle.png", Price = 999, LimitedItem = false },
                    },
                    SpeechGreetings = new List<string>()
                    {
                        "[The meek salamander befuddles you with his shockingly intoxicating voice] Why hello there, traveler! Welcome to my shop!",
                        "Ah yes, I see you’re a seasoned veteran!",
                        "[You notice brutality behind the salamander’s beady eyes]",
                    },
                    SpeechPurchased = new List<string>()
                    {
                        "Good luck out there soldier.",
                        "It’s refreshing to see folks with bravery in their hearts!",
                        "You made the right choice doing business with me.",
                    },
                    SpeechSoldOut = new List<string>()
                    {
                        "SoldOut1",
                    },
                    SpeechCantAfford = new List<string>()
                    {
                        "Sorry soldier, those are for the tough guys.",
                        "You look a bit weak to be handling that one.",
                        "Looks a bit too heavy for you at the moment.",
                    },
                    SpeechFullFood = new List<string>()
                    {
                        "FullFood1",
                    },
                    SpeechFullWater = new List<string>()
                    {
                        "FullWater1",
                    },
                    SpeechNoSpace = new List<string>()
                    {
                        "Your battlefield is crowded already.",
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

        public static void InvokeSpeechSoldOut()
        {
            if (CurDialogState != DialogState.Soldout)
            {
                CurStore.CurSpeech = CurStore.SpeechSoldOut[RandomNumberGenerator.GetInt32(0, CurStore.SpeechSoldOut.Count)];
                CurDialogState = DialogState.Soldout;
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

        public static void InvokeSpeechFullFood()
        {
            if (CurDialogState != DialogState.FullFood)
            {
                CurStore.CurSpeech = CurStore.SpeechFullFood[RandomNumberGenerator.GetInt32(0, CurStore.SpeechFullFood.Count)];
                CurDialogState = DialogState.FullFood;
            }

            InvokeStoreRefresh();
        }

        public static void InvokeSpeechFullWater()
        {
            if (CurDialogState != DialogState.FullWater)
            {
                CurStore.CurSpeech = CurStore.SpeechFullWater[RandomNumberGenerator.GetInt32(0, CurStore.SpeechFullWater.Count)];
                CurDialogState = DialogState.FullWater;
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
