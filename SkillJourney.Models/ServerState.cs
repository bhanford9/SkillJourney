using CommunityToolkit.Mvvm.Messaging;
using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Models.Messages;

namespace SkillJourney.Models;

public interface IServerState
{
    bool IsConnected { get; }

    Task<bool> CheckConnection();
}

internal class ServerState : IServerState
{
    private readonly IMessenger messenger;
    private readonly IServerStateClient serverStateClient;
    private readonly IMessagesFactory messagesFactory;
    private bool isConnected = false;
    
    public ServerState(IMessenger messenger, IServerStateClient serverStateClient, IMessagesFactory messagesFactory)
    {
        this.messenger = messenger;
        this.serverStateClient = serverStateClient;
        this.messagesFactory = messagesFactory;
    }

    public bool IsConnected
    {
        get => this.isConnected;
        private set
        {
            if (this.isConnected != value)
            {
                this.isConnected = value;
                this.messenger.Send(messagesFactory.BuildServerStateChangedMessage(this));
            }
        }
    }

    public async Task<bool> CheckConnection() => this.IsConnected = await this.serverStateClient.IsConnected();
}
