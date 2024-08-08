using SkillJourney.Api.Shared.Contract.SkillCategories;
using SkillJourney.Database.SkillCategories;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface ISkillCategoryContractBuilder
{
    SkillCategoryContract BuildContract(ISkillCategoryEntry businessArea);
}

public class SkillCategoryContractBuilder : ISkillCategoryContractBuilder
{
    public SkillCategoryContract BuildContract(ISkillCategoryEntry businessArea)
        => new(businessArea.Id, businessArea.Name);
}
