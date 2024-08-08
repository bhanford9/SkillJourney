using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.OccupationalTitles;
using SkillJourney.Database.OccupationalTitles;

namespace SkillJourney.Api.Server.Controllers;

public interface IOccupationalTitleController
{
    OccupationalTitleContract FromId(Guid id);
}

public class OccupationalTitleController : IOccupationalTitleController
{
    private readonly IOccupationalTitlesDatabaseApi businessAreasDatabaseApi;
    private readonly IOccupationalTitleContractBuilder businessAreaContractBuilder;

    public OccupationalTitleController(
        IOccupationalTitlesDatabaseApi businessAreasDatabaseApi,
        IOccupationalTitleContractBuilder businessAreaContractBuilder)
    {
        this.businessAreasDatabaseApi = businessAreasDatabaseApi;
        this.businessAreaContractBuilder = businessAreaContractBuilder;
    }

    public OccupationalTitleContract FromId(Guid id)
        => businessAreaContractBuilder.BuildContract(businessAreasDatabaseApi.GetOccupationalTitleById(id));
}
