using SkillJourney.Api.Shared.Contract.SkillFields;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface ISkillFieldContractBuilder
{
    SkillFieldContract BuildContract(ISkillFieldEntry skillCategory);
}

public class SkillFieldContractBuilder : ISkillFieldContractBuilder
{
    public SkillFieldContract BuildContract(ISkillFieldEntry skillCategory)
        => new(skillCategory.Id, skillCategory.Name);
}
