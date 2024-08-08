using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SkillJourney.ViewModels.Messages;
using SkillJourney.ViewModels.SkillRatings;

namespace SkillJourney.ViewModels.NotableHighlights;

public interface INotableHighlightFormViewModel : IViewModel
{
    int SignificanceRating { get; set; }
    string Description { get; set;}
    DateTime? DateOfOccurrence { get; set; }
    IReadOnlyList<ISkillRatingViewModel> RelatedSkillRatings { get; set;}

    void NotifyFormComplete();
}

internal partial class NotableHighlightFormViewModel : ViewModel, INotableHighlightFormViewModel
{
    private readonly IMessenger messenger;
    private readonly IMessagesFactory messagesFactory;
    [ObservableProperty] int significanceRating;
    [ObservableProperty] string description = string.Empty;
    [ObservableProperty] DateTime? dateOfOccurrence = DateTime.Today;
    [ObservableProperty] IReadOnlyList<ISkillRatingViewModel> relatedSkillRatings = [];

    public NotableHighlightFormViewModel(IMessenger messenger, IMessagesFactory messagesFactory)
    {
        this.messenger = messenger;
        this.messagesFactory = messagesFactory;
    }

    public void NotifyFormComplete() => messenger.Send(messagesFactory.BuildHighlightFormCompletedMessage(this));
}
