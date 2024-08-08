using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using MudBlazor;
using SkillJourney.Models.NotableHighlights;
using SkillJourney.Models.Users;
using SkillJourney.ViewModels.Messages;

namespace SkillJourney.ViewModels.NotableHighlights;

public interface INotableHighlightsListViewModel : IViewModel
{
    ObservableCollection<INotableHighlightViewModel> NotableHighlights { get; }

    Task AddHighlight(INotableHighlightAddedMessage highlight);
    Task CreateNewHighlight(Type dialogViewType);
}
internal class NotableHighlightsListViewModel : ViewModel, INotableHighlightsListViewModel
{
    private readonly ICurrentUserModel userModel;
    private readonly INotableHighlightsListModel notableHighlights;
    private readonly IViewModelFactory viewModelFactory;
    private readonly IDialogService dialogService;

    public NotableHighlightsListViewModel(
        IMessenger messenger,
        ICurrentUserModel userModel,
        INotableHighlightsListModel notableHighlights,
        IViewModelFactory viewModelFactory,
        IDialogService dialogService)
    {
        messenger.Register<INotableHighlightsListViewModel, INotableHighlightAddedMessage>(this, (r, m) => r.AddHighlight(m));
        this.userModel = userModel;
        this.notableHighlights = notableHighlights;
        this.viewModelFactory = viewModelFactory;
        this.dialogService = dialogService;
    }

    public ObservableCollection<INotableHighlightViewModel> NotableHighlights { get; } = [];

    public async Task CreateNewHighlight(Type dialogViewType)
    {
        await dialogService.ShowAsync(dialogViewType, "Add Highlight");
    }

    public async Task AddHighlight(INotableHighlightAddedMessage highlight)
    {
        var result = await notableHighlights.CreateNotableHighlightForUser(
            userModel.CurrentUser,
            highlight.Value.SignificanceRating,
            highlight.Value.Description,
            highlight.Value.DateOfOccurrence ?? DateTime.Now,
            highlight.Value.RelatedSkillRatings.Select(x => x.SkillRatingModel).ToList());

        NotableHighlights.Add(viewModelFactory.BuildNotableHighlight(result));
    }
}
