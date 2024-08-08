using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Database.SkillRatings;

namespace SkillJourney.Api.Server.Controllers;

public interface ISkillRatingController
{
    IReadOnlyList<SkillRatingContract> GetAllRatings();
    SkillRatingContract GetRatingById(Guid id);
}

public class SkillRatingController : ISkillRatingController
{
    private readonly ISkillRatingContractBuilder skillRatingContractBuilder;
    private readonly ISkillRatingsDatabaseApi skillRatingsDatabaseApi;
    private readonly IBusinessAreaController businessAreaController;
    private readonly ISkillCategoryController skillCategoryController;
    private readonly ISkillFieldController skillFieldController;

    public SkillRatingController(
        ISkillRatingsDatabaseApi skillRatingsDatabaseApi,
        ISkillRatingContractBuilder skillRatingContractBuilder,
        IBusinessAreaController businessAreaController,
        ISkillCategoryController skillCategoryController,
        ISkillFieldController skillFieldController)
    {
        this.skillRatingsDatabaseApi = skillRatingsDatabaseApi;
        this.businessAreaController = businessAreaController;
        this.skillCategoryController = skillCategoryController;
        this.skillFieldController = skillFieldController;
        this.skillRatingContractBuilder = skillRatingContractBuilder;
    }

    public IReadOnlyList<SkillRatingContract> GetAllRatings() => skillRatingsDatabaseApi
        .GetAllRatings()
        .Select(entry => BuildContract(entry, entry.BusinessArea, entry.SkillField, entry.SkillCategory))
        .ToList();

    public SkillRatingContract GetRatingById(Guid id)
    {
        var entry = skillRatingsDatabaseApi.GetRatingById(id);
        return BuildContract(entry, entry.BusinessArea, entry.SkillField, entry.SkillCategory);
    }

    private SkillRatingContract BuildContract(ISkillRatingEntry entry, Guid businessArea, Guid skillField, Guid skillCategory)
        => skillRatingContractBuilder.BuildContract(
            entry,
            businessAreaController.FromId(businessArea),
            skillFieldController.FromId(skillField),
            skillCategoryController.FromId(skillCategory));
}
