using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Database.BusinessAreas;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface IBusinessAreaContractBuilder
{
    BusinessAreaContract BuildContract(IBusinessAreaEntry businessArea);
}

public class BusinessAreaContractBuilder : IBusinessAreaContractBuilder
{
    public BusinessAreaContract BuildContract(IBusinessAreaEntry businessArea)
        => new(businessArea.Id, businessArea.Name);
}
