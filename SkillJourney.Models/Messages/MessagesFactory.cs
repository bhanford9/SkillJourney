namespace SkillJourney.Models.Messages;

internal interface IMessagesFactory
{
    IServerStateChangedMessage BuildServerStateChangedMessage(IServerState state);
}

internal class MessagesFactory : IMessagesFactory
{
    public IServerStateChangedMessage BuildServerStateChangedMessage(IServerState state)
        => new ServerStateChangedMessage(state);
}
