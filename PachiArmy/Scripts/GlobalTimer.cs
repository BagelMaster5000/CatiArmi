using Timer = System.Timers.Timer;

namespace PachiArmy.Scripts
{
    public static class GlobalTimer
    {
        public static Timer TickTimer;
        public static void StartTickTimer()
        {
            if (TickTimer != null)
            {
                TickTimer.Stop();
            }

            TickTimer = new Timer(GameManager.TickTimeSeconds * 1000);
            TickTimer.AutoReset = true;
            TickTimer.Enabled = true;
            TickTimer.Start();
        }

        public static Timer RefreshTimer;
        public static void StartRefreshTimer()
        {
            if (RefreshTimer != null)
            {
                RefreshTimer.Stop();
            }

            RefreshTimer = new Timer(GameManager.RefreshTimeSeconds * 1000);
            RefreshTimer.AutoReset = true;
            RefreshTimer.Enabled = true;
            RefreshTimer.Start();
        }
    }
}
