using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.NotableHighlights;

namespace SkillJourney.Api.Server.Apis;

public interface INotableHighlightsApi
{
    Task<IReadOnlyList<NotableHighlightContract>> GetHighlightsForUser(Guid user);
    Task<NotableHighlightContract> AddHighlight(AddNotableHighlightContract addNotableHighlightContract);
}

internal class NotableHighlightsApi : INotableHighlightsApi
{
    private readonly INotableHighlightController highlightsController;
    private readonly IContractBuilderProvider contractBuilders;
    private readonly ISkillRatingsApi skillRatingsApi;

    public NotableHighlightsApi(
        INotableHighlightController highlightController,
        IContractBuilderProvider contractBuilders,
        ISkillRatingsApi skillRatingsApi)
    {
        this.highlightsController = highlightController;
        this.contractBuilders = contractBuilders;
        this.skillRatingsApi = skillRatingsApi;
    }

    public async Task<IReadOnlyList<NotableHighlightContract>> GetHighlightsForUser(Guid user)
        => (await Task.WhenAll(highlightsController
            .GetUserHighlights(user)
            .Select(BuildFullContract)))
        .ToList();

    public Task<NotableHighlightContract> AddHighlight(AddNotableHighlightContract addNotableHighlightContract)
        => BuildFullContract(highlightsController.AddHighlight(addNotableHighlightContract));

    private async Task<NotableHighlightContract> BuildFullContract(NotableHighlightSubContract highlight)
        => contractBuilders.NotableHighlight.BuildContract(
            highlight,
            (await Task.WhenAll(highlightsController.GetRelatedSkills(highlight.Id).Select(BuildFullContract))).ToList());

    private async Task<NotableHighlightRelatedSkillContract> BuildFullContract(NotableHighlightRelatedSkillSubContract relatedSkill)
        => contractBuilders.NotableHighlightRelatedSkill.BuildContract(
            relatedSkill,
            await skillRatingsApi.GetSkillRatingById(relatedSkill.SkillRating));

}