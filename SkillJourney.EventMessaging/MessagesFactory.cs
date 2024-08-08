namespace SkillJourney.EventMessaging;
internal interface IMessagesFactory
{
    INotableHighlightAddedMessage BuildHighlightFormCompletedMessage(INotableHighlightFormViewModel viewModel);
}

internal class MessagesFactory : IMessagesFactory
{
    public INotableHighlightAddedMessage BuildHighlightFormCompletedMessage(INotableHighlightFormViewModel viewModel)
        => new NotableHighlightAddedMessage(viewModel);
}
