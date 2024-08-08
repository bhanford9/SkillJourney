using CommunityToolkit.Mvvm.Messaging;
using SkillJourney.Models;
using SkillJourney.Models.Messages;
using static SkillJourney.ViewModels.ConnectionEvents;

namespace SkillJourney.ViewModels;

public class ConnectionEvents
{
    public delegate Task ConnectionStateChangedHandler();
}
public interface IServerStateViewModel : IViewModel
{
    bool IsConnected { get; }

    void Receive(IServerStateChangedMessage message);

    event ConnectionStateChangedHandler? ConnectionStateChanged;
}

internal partial class ServerStateViewModel : ViewModel, IRecipient<IServerStateChangedMessage>, IServerStateViewModel
{
    private readonly IServerStateMonitor serverStateMonitor;
    private readonly IServerState serverState;

    public event ConnectionStateChangedHandler? ConnectionStateChanged;

    public ServerStateViewModel(IServerStateMonitor serverStateMonitor, IMessenger messenger)
    {
        this.serverStateMonitor = serverStateMonitor;
        this.serverState = serverStateMonitor.ServerState;
        messenger.Register<IServerStateViewModel, IServerStateChangedMessage>(this, (r, m) => r.Receive(m));
    }

    public bool IsConnected => serverState.IsConnected;

    public void Receive(IServerStateChangedMessage message) => ConnectionStateChanged?.Invoke();
}
