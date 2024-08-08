using SkillJourney.Api.Shared.Contract.OccupationalTitles;
using SkillJourney.Database.OccupationalTitles;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface IOccupationalTitleContractBuilder
{
    OccupationalTitleContract BuildContract(IOccupationalTitleEntry businessArea);
}

public class OccupationalTitleContractBuilder : IOccupationalTitleContractBuilder
{
    public OccupationalTitleContract BuildContract(IOccupationalTitleEntry businessArea)
        => new(businessArea.Id, businessArea.Name);
}
