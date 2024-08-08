using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Database.NotableHighlights;

namespace SkillJourney.Api.Server.Controllers;

public interface INotableHighlightController
{
    NotableHighlightSubContract FromId(Guid id);
    IReadOnlyList<NotableHighlightSubContract> GetUserHighlights(Guid userId);
    NotableHighlightSubContract AddHighlight(AddNotableHighlightContract addNotableHighlightContract);
    IReadOnlyList<NotableHighlightRelatedSkillSubContract> GetRelatedSkills(Guid highlight);
}

public class NotableHighlightController : INotableHighlightController
{
    private readonly INotableHighlightsDatabaseApi notableHighlightsDatabaseApi;
    private readonly INotableHighlightContractBuilder notableHighlightContractBuilder;
    private readonly INotableHighlightRelatedSkillContractBuilder notableHighlightRelatedSkillContractBuilder;

    public NotableHighlightController(
        INotableHighlightsDatabaseApi notableHighlightsDatabaseApi,
        INotableHighlightContractBuilder notableHighlightContractBuilder,
        INotableHighlightRelatedSkillContractBuilder notableHighlightRelatedSkillContractBuilder)
    {
        this.notableHighlightsDatabaseApi = notableHighlightsDatabaseApi;
        this.notableHighlightContractBuilder = notableHighlightContractBuilder;
        this.notableHighlightRelatedSkillContractBuilder = notableHighlightRelatedSkillContractBuilder;
    }

    public IReadOnlyList<NotableHighlightSubContract> GetUserHighlights(Guid userId) => notableHighlightsDatabaseApi
        .GetHighlightsForUser(userId)
        .Select(notableHighlightContractBuilder.BuildSubContract)
        .ToList();

    public NotableHighlightSubContract AddHighlight(AddNotableHighlightContract addNotableHighlightContract)
        => notableHighlightContractBuilder.BuildSubContract(notableHighlightsDatabaseApi.AddHighlight(
            addNotableHighlightContract.ReceivingUser,
            addNotableHighlightContract.SignificanceRating,
            addNotableHighlightContract.Description,
            addNotableHighlightContract.DateOfOccurrence,
            addNotableHighlightContract.RelatedSkillRatings));

    public NotableHighlightSubContract FromId(Guid id)
        => notableHighlightContractBuilder.BuildSubContract(notableHighlightsDatabaseApi.GetHighlightById(id));

    public IReadOnlyList<NotableHighlightRelatedSkillSubContract> GetRelatedSkills(Guid highlight)
        => notableHighlightsDatabaseApi
        .GetHighlightRelatedSkills(highlight)
        .Select(notableHighlightRelatedSkillContractBuilder.BuildSubContract)
        .ToList();
}
