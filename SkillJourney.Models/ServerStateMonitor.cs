namespace SkillJourney.Models;

public interface IServerStateMonitor
{
    IServerState ServerState { get; }

    void Dispose();
    void ReStart();
    void Stop();
}

internal class ServerStateMonitor : IDisposable, IServerStateMonitor
{
    private System.Timers.Timer monitor = default!;
    private bool isStopped = false;

    // Ideally, only need to run this on startup and/or for debug purposes
    // Checking the connection of the server state will notify everyone
    public ServerStateMonitor(IServerState serverState)
    {
        ServerState = serverState;
        monitor = new(TimeSpan.FromSeconds(2));
        monitor.AutoReset = true;
        ReStart();
    }

    public IServerState ServerState { get; }

    public void Dispose()
    {
        monitor.Stop();
        monitor.Dispose();
    }

    public void ReStart()
    {
        Stop();
        isStopped = false;
        monitor.Elapsed += async (_, _) =>
        {
            if (!isStopped && await ServerState.CheckConnection())
                Stop();
        };
        monitor.Start();
    }

    public void Stop()
    { 
        isStopped = true;
        monitor.Stop();
    }
}
