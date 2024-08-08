using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Database.SkillCategories;

namespace SkillJourney.Api.Server.Controllers;

public interface ISkillCategoryController
{
    SkillCategoryContract FromId(Guid id);
}

public class SkillCategoryController : ISkillCategoryController
{
    private readonly ISkillCategoriesDatabaseApi skillCategoryDatabaseApi;
    private readonly ISkillCategoryContractBuilder skillCategoryContractBuilder;

    public SkillCategoryController(
        ISkillCategoriesDatabaseApi skillCategoryDatabaseApi,
        ISkillCategoryContractBuilder skillCategoryContractBuilder)
    {
        this.skillCategoryDatabaseApi = skillCategoryDatabaseApi;
        this.skillCategoryContractBuilder = skillCategoryContractBuilder;
    }

    public SkillCategoryContract FromId(Guid id) => skillCategoryContractBuilder.BuildContract(skillCategoryDatabaseApi.GetSkillCategoryById(id));

}
