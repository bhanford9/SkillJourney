using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.SkillRatings;

namespace SkillJourney.Api.Server.Apis;

public interface ISkillRatingsApi
{
    Task<IReadOnlyList<SkillRatingContract>> GetAllSkillRatings();
    Task<SkillRatingContract> GetSkillRatingById(Guid id);
}

public class SkillRatingsApi : ISkillRatingsApi
{
    private readonly ISkillRatingController ratingController;

    public SkillRatingsApi(ISkillRatingController ratingController) => this.ratingController = ratingController;

    public Task<IReadOnlyList<SkillRatingContract>> GetAllSkillRatings()
        => Task.FromResult<IReadOnlyList<SkillRatingContract>>(ratingController.GetAllRatings().ToList());

    public async Task<SkillRatingContract> GetSkillRatingById(Guid id)
        => await Task.FromResult(ratingController.GetRatingById(id));
}
