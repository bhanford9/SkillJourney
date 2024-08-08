using SkillJourney.Api.Shared.Contract.OccupationalTitles;
using SkillJourney.Models.OccupationalTitles;

namespace SkillJourney.Models.ContractAdapters;
public interface IOccupationalTitlesAdapter
{
    IOccupationalTitleModel ToModel(OccupationalTitleContract occupationalTitle);
}

internal class OccupationalTitlesAdapter : IOccupationalTitlesAdapter
{
    private readonly IOccupationalTitleFactory occupationalTitleFactory;

    public OccupationalTitlesAdapter(IOccupationalTitleFactory occupationalTitleFactory)
    {
        this.occupationalTitleFactory = occupationalTitleFactory;
    }

    public IOccupationalTitleModel ToModel(OccupationalTitleContract occupationalTitle)
        => occupationalTitleFactory.CreateOccupationalTitle(occupationalTitle.Id, occupationalTitle.Name);
}
