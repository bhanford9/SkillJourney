using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SkillJourney.Models.Messages;

public interface IServerStateChangedMessage : IEquatable<IServerStateChangedMessage>
{
    IServerState Value { get; }
}
public class ServerStateChangedMessage : ValueChangedMessage<IServerState>, IServerStateChangedMessage
{
    public ServerStateChangedMessage(IServerState value) : base(value) { }

    public bool Equals(IServerStateChangedMessage? other) => other is not null && other.Value.Equals(Value);
}
