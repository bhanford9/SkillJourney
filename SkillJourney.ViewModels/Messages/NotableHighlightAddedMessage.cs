using CommunityToolkit.Mvvm.Messaging.Messages;
using SkillJourney.ViewModels.NotableHighlights;

namespace SkillJourney.ViewModels.Messages;
public interface INotableHighlightAddedMessage : IEquatable<INotableHighlightAddedMessage>
{
    INotableHighlightFormViewModel Value { get; }
}
internal class NotableHighlightAddedMessage : ValueChangedMessage<INotableHighlightFormViewModel>, INotableHighlightAddedMessage
{
    public NotableHighlightAddedMessage(INotableHighlightFormViewModel value) : base(value)
    {
    }

    public bool Equals(INotableHighlightAddedMessage? other) => other is not null && other.Value.Equals(Value);
}
