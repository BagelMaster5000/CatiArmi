using System.Timers;
using Timer = System.Timers.Timer;

namespace PachiArmy.Scripts
{
    public static class GlobalTimer
    {
        public static Timer Timer;
        public static void StartTimer()
        {
            Timer = new Timer(1000);
            Timer.AutoReset = true;
            Timer.Enabled = true;
            Timer.Start();
        }
    }
}
