using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Models.BusinessAreas;

namespace SkillJourney.Models.ContractAdapters;

public interface IBusinessAreasAdapter
{
    IBusinessAreaModel ToModel(BusinessAreaContract businessArea);
}

internal class BusinessAreasAdapter : IBusinessAreasAdapter
{
    private readonly IBusinessAreaFactory businessAreaFactory;

    public BusinessAreasAdapter(IBusinessAreaFactory businessAreaFactory)
    {
        this.businessAreaFactory = businessAreaFactory;
    }

    public IBusinessAreaModel ToModel(BusinessAreaContract businessArea)
        => businessAreaFactory.CreateBusinessArea(businessArea.Id, businessArea.Name);
}
