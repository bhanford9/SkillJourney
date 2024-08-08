using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using SkillJourney.Models.ContractAdapters;
using SkillJourney.Models.Messages;

namespace SkillJourney.Models.SkillRatings;

public interface ISkillRatings
{
    IReadOnlyList<ISkillRatingModel> Ratings { get; }

    Task GetAllRatings();
    void Receive(IServerStateChangedMessage message);
}
internal partial class SkillRatings : ObservableObject, ISkillRatings, IRecipient<IServerStateChangedMessage>
{
    private readonly IMessenger messenger;
    private readonly ISkillRatingsAdapter skillRatingsAdapter;
    private readonly IServerState serverState;

    [ObservableProperty]
    private IReadOnlyList<ISkillRatingModel> ratings = [];

    public SkillRatings(IMessenger messenger, ISkillRatingsAdapter skillRatingsAdapter, IServerState serverState)
    {
        this.messenger = messenger;
        this.skillRatingsAdapter = skillRatingsAdapter;
        this.serverState = serverState;
    }

    public async Task GetAllRatings()
    {
        if (serverState.IsConnected)
        {
            Ratings = await skillRatingsAdapter.GetAllSkillRatings();
        }
        else
        {
            messenger.Register<ISkillRatings, IServerStateChangedMessage>(this, (r, m) => r.Receive(m));
        }
    }

    public async void Receive(IServerStateChangedMessage message)
    {
        Ratings = await skillRatingsAdapter.GetAllSkillRatings();
        messenger.Unregister<ISkillRatings, IServerStateChangedMessage>(this, message);
    }
}
