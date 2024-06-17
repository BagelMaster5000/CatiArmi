namespace PachiArmy.Scripts
{
    public static class GameManager
    {
        public static void ClearAllDelegateSubscriptions()
        {
            BoardManager.ClearForceBoardRefresh();
            Inventory.ClearResourcesUpdated();
            GlobalTimer.StartRefreshTimer();
            GlobalTimer.StartTickTimer();
        }

        public static uint PachisToWin = 100;
    }
}
