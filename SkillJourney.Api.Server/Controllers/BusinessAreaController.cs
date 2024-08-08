using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.BusinessAreas;
using SkillJourney.Database.BusinessAreas;

namespace SkillJourney.Api.Server.Controllers;

public interface IBusinessAreaController
{
    BusinessAreaContract FromId(Guid id);
}

public class BusinessAreaController : IBusinessAreaController
{
    private readonly IBusinessAreasDatabaseApi businessAreasDatabaseApi;
    private readonly IBusinessAreaContractBuilder businessAreaContractBuilder;

    public BusinessAreaController(
        IBusinessAreasDatabaseApi businessAreasDatabaseApi,
        IBusinessAreaContractBuilder businessAreaContractBuilder)
    {
        this.businessAreasDatabaseApi = businessAreasDatabaseApi;
        this.businessAreaContractBuilder = businessAreaContractBuilder;
    }

    public BusinessAreaContract FromId(Guid id)
        => businessAreaContractBuilder.BuildContract(businessAreasDatabaseApi.GetBusinessAreaById(id));
}
