using System.Timers;
using Timer = System.Timers.Timer;

namespace CatiArmi.Scripts
{
    public static class GlobalTimer
    {
        public static Timer TickTimer = new Timer(GameManager.TickTimeSeconds * 1000);
        public static void StartTickTimer()
        {
            if (TickTimer != null)
            {
                TickTimer.Stop();
            }

            TickTimer.AutoReset = true;
            TickTimer.Enabled = true;
            TickTimer.Start();
        }

        public static Timer RefreshTimer = new Timer(GameManager.RefreshTimeSeconds * 1000);
        public static void StartRefreshTimer()
        {
            if (RefreshTimer != null)
            {
                RefreshTimer.Stop();
            }

            RefreshTimer.AutoReset = true;
            RefreshTimer.Enabled = true;
            RefreshTimer.Start();
        }
    }
}
