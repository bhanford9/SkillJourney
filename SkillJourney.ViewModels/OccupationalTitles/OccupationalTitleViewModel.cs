using SkillJourney.Models.OccupationalTitles;

namespace SkillJourney.ViewModels.OccupationalTitles;

public interface IOccupationalTitleViewModel : IViewModel
{
    Guid Id { get; }

    string Name { get; }
}

internal partial class OccupationalTitleViewModel : ViewModel, IOccupationalTitleViewModel
{
    private readonly IOccupationalTitleModel model;

    public OccupationalTitleViewModel(IOccupationalTitleModel model)
    {
        this.model = model;
    }

    public Guid Id => model.Id;

    public string Name => model.Name;
}
