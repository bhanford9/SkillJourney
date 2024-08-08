using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Database.NotableHighlights;

namespace SkillJourney.Api.Server.Controllers;

public interface INotableHighlightController
{
    NotableHighlightContract FromId(Guid id);
    IReadOnlyList<NotableHighlightContract> GetUserHighlights(Guid userId);
    NotableHighlightContract AddHighlight(AddNotableHighlightContract addNotableHighlightContract);
    IReadOnlyList<NotableHighlightRelatedSkillContract> GetRelatedSkills(Guid highlight);
}

public class NotableHighlightController : INotableHighlightController
{
    private readonly INotableHighlightsDatabaseApi notableHighlightsDatabaseApi;
    private readonly INotableHighlightContractBuilder notableHighlightContractBuilder;
    private readonly INotableHighlightRelatedSkillContractBuilder notableHighlightRelatedSkillContractBuilder;
    private readonly ISkillRatingController skillRatingController;

    public NotableHighlightController(
        INotableHighlightsDatabaseApi notableHighlightsDatabaseApi,
        INotableHighlightContractBuilder notableHighlightContractBuilder,
        INotableHighlightRelatedSkillContractBuilder notableHighlightRelatedSkillContractBuilder,
        ISkillRatingController skillRatingController)
    {
        this.notableHighlightsDatabaseApi = notableHighlightsDatabaseApi;
        this.notableHighlightContractBuilder = notableHighlightContractBuilder;
        this.notableHighlightRelatedSkillContractBuilder = notableHighlightRelatedSkillContractBuilder;
        this.skillRatingController = skillRatingController;
    }

    public IReadOnlyList<NotableHighlightContract> GetUserHighlights(Guid userId) => notableHighlightsDatabaseApi
        .GetHighlightsForUser(userId)
        .Select(BuildContract)
        .ToList();

    public NotableHighlightContract AddHighlight(AddNotableHighlightContract addNotableHighlightContract)
        => BuildContract(notableHighlightsDatabaseApi.AddHighlight(
            addNotableHighlightContract.ReceivingUser,
            addNotableHighlightContract.SignificanceRating,
            addNotableHighlightContract.Description,
            addNotableHighlightContract.DateOfOccurrence,
            addNotableHighlightContract.RelatedSkillRatings));

    public NotableHighlightContract FromId(Guid id) => BuildContract(notableHighlightsDatabaseApi.GetHighlightById(id));

    public IReadOnlyList<NotableHighlightRelatedSkillContract> GetRelatedSkills(Guid highlight)
        => notableHighlightsDatabaseApi
        .GetHighlightRelatedSkills(highlight)
        .Select(BuildContract)
        .ToList();

    private NotableHighlightRelatedSkillContract BuildContract(INotableHighlightRelatedSkillEntry entry)
        => notableHighlightRelatedSkillContractBuilder.BuildContract(
            entry,
            skillRatingController.GetRatingById(entry.RelatedSkill));

    private NotableHighlightContract BuildContract(INotableHighlightEntry entry)
        => notableHighlightContractBuilder.BuildContract(
            entry,
            GetRelatedSkills(entry.Id));
}
