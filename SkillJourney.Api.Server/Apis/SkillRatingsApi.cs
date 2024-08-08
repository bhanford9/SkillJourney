using SkillJourney.Api.Server.ContractBuilders;
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
    private readonly ISkillRatingContractBuilder skillRatingContractBuilder;
    private readonly IBusinessAreaController businessAreaController;
    private readonly ISkillCategoryController skillCategoryController;
    private readonly ISkillFieldController skillFieldController;

    public SkillRatingsApi(
        ISkillRatingController ratingController,
        ISkillRatingContractBuilder skillRatingContractBuilder,
        IBusinessAreaController businessAreaController,
        ISkillCategoryController skillCategoryController,
        ISkillFieldController skillFieldController)
    {
        this.ratingController = ratingController;
        this.skillRatingContractBuilder = skillRatingContractBuilder;
        this.businessAreaController = businessAreaController;
        this.skillCategoryController = skillCategoryController;
        this.skillFieldController = skillFieldController;
    }

    public Task<IReadOnlyList<SkillRatingContract>> GetAllSkillRatings()
        => Task.FromResult<IReadOnlyList<SkillRatingContract>>(ratingController
            .GetAllRatings()
            .Select(BuildFullContract)
            .ToList());

    public async Task<SkillRatingContract> GetSkillRatingById(Guid id)
        => await Task.FromResult(BuildFullContract(ratingController.GetRatingById(id)));

    private SkillRatingContract BuildFullContract(
        SkillRatingSubContract rating)
        => skillRatingContractBuilder.BuildContract(
                rating,
                businessAreaController.FromId(rating.BusinessArea),
                skillFieldController.FromId(rating.SkillField),
                skillCategoryController.FromId(rating.SkillCategory));
}
