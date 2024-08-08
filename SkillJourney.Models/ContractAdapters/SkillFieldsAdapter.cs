using SkillJourney.Api.Shared.Contract.SkillFields;
using SkillJourney.Models.SkillFields;

namespace SkillJourney.Models.ContractAdapters;
public interface ISkillFieldsAdapter
{
    ISkillFieldModel ToModel(SkillFieldContract skillField);
}

internal class SkillFieldsAdapter : ISkillFieldsAdapter
{
    private readonly ISkillFieldFactory skillFieldFactory;

    public SkillFieldsAdapter(ISkillFieldFactory skillFieldFactory)
    {
        this.skillFieldFactory = skillFieldFactory;
    }

    public ISkillFieldModel ToModel(SkillFieldContract skillField)
        => skillFieldFactory.CreateSkillField(skillField.Id, skillField.Name);
}
