using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.SkillFields;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Api.Server.Controllers;

public interface ISkillFieldController
{
    SkillFieldContract FromId(Guid id);
}

public class SkillFieldController : ISkillFieldController
{
    private readonly ISkillFieldsDatabaseApi skillCategorysDatabaseApi;
    private readonly ISkillFieldContractBuilder skillFieldContractBuilder;

    public SkillFieldController(
        ISkillFieldsDatabaseApi skillCategorysDatabaseApi,
        ISkillFieldContractBuilder skillFieldContractBuilder)
    {
        this.skillCategorysDatabaseApi = skillCategorysDatabaseApi;
        this.skillFieldContractBuilder = skillFieldContractBuilder;
    }

    public SkillFieldContract FromId(Guid id)
        => skillFieldContractBuilder.BuildContract(skillCategorysDatabaseApi.GetSkillFieldById(id));

}
