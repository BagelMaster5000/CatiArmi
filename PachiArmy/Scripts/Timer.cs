using System.Timers;
using Timer = System.Timers.Timer;

public class JobExecutedEventArgs : EventArgs { }

public class PeriodicExecutor : IDisposable
{
    public event EventHandler<JobExecutedEventArgs> OnTick;

    Timer _Timer;
    bool _Running;

    public void StartExecuting()
    {
        if (!_Running)
        {
            // Initiate a Timer
            _Timer = new Timer();
            _Timer.Interval = 1000;  // every 5 mins
            _Timer.Elapsed += HandleTimer;
            _Timer.AutoReset = true;
            _Timer.Enabled = true;

            _Running = true;
        }
    }
    void HandleTimer(object source, ElapsedEventArgs e)
    {
        OnTick?.Invoke(this, new JobExecutedEventArgs());
    }
    public void Dispose()
    {
        if (_Running)
        {
            _Timer.Dispose();
        }
    }
}
