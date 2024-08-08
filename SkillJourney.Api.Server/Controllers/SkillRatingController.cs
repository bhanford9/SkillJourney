using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Database.SkillRatings;

namespace SkillJourney.Api.Server.Controllers;

public interface ISkillRatingController
{
    IReadOnlyList<SkillRatingSubContract> GetAllRatings();
    SkillRatingSubContract GetRatingById(Guid id);
}

public class SkillRatingController : ISkillRatingController
{
    private readonly ISkillRatingContractBuilder skillRatingContractBuilder;
    private readonly ISkillRatingsDatabaseApi skillRatingsDatabaseApi;

    public SkillRatingController(
        ISkillRatingContractBuilder skillRatingContractBuilder,
        ISkillRatingsDatabaseApi skillRatingsDatabaseApi)
    {
        this.skillRatingsDatabaseApi = skillRatingsDatabaseApi;
        this.skillRatingContractBuilder = skillRatingContractBuilder;
    }

    public IReadOnlyList<SkillRatingSubContract> GetAllRatings() => skillRatingsDatabaseApi
        .GetAllRatings()
        .Select(skillRatingContractBuilder.BuildSubContract)
        .ToList();

    public SkillRatingSubContract GetRatingById(Guid id)
        => skillRatingContractBuilder.BuildSubContract(skillRatingsDatabaseApi.GetRatingById(id));
}
