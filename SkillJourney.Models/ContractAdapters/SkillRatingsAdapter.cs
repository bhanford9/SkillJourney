using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.SkillRatings;
using SkillJourney.Models.SkillRatings;

namespace SkillJourney.Models.ContractAdapters;

internal interface ISkillRatingsAdapter
{
    Task<IReadOnlyList<ISkillRatingModel>> GetAllSkillRatings();
    ISkillRatingModel ToModel(SkillRatingContract contract);
}

internal class SkillRatingsAdapter : ISkillRatingsAdapter
{
    private readonly ISkillRatingsClient skillRatingsClient;
    private readonly ISkillRatingFactory skillRatingFactory;
    private readonly IBusinessAreasAdapter businessAreasAdapter;
    private readonly ISkillFieldsAdapter skillFieldsAdapter;
    private readonly ISkillCategoriesAdapter skillCategoriesAdapter;

    public SkillRatingsAdapter(
        ISkillRatingsClient skillRatingsClient,
        ISkillRatingFactory skillRatingFactory,
        IBusinessAreasAdapter businessAreasAdapter,
        ISkillFieldsAdapter skillFieldsAdapter,
        ISkillCategoriesAdapter skillCategoriesAdapter)
    {
        this.skillRatingsClient = skillRatingsClient;
        this.skillRatingFactory = skillRatingFactory;
        this.businessAreasAdapter = businessAreasAdapter;
        this.skillFieldsAdapter = skillFieldsAdapter;
        this.skillCategoriesAdapter = skillCategoriesAdapter;
    }

    public async Task<IReadOnlyList<ISkillRatingModel>> GetAllSkillRatings()
    =>
        (await this.skillRatingsClient.GetAllSkillRatings())?
            .Select(ToModel)
            .ToList() ?? [];

    public ISkillRatingModel ToModel(SkillRatingContract contract) => skillRatingFactory.BuildSkillRating(
        contract.Id,
        contract.Name,
        contract.Description,
        businessAreasAdapter.ToModel(contract.BusinessArea),
        skillFieldsAdapter.ToModel(contract.SkillField),
        skillCategoriesAdapter.ToModel(contract.SkillCategory),
        contract.IsObsolete,
        AdaptValue(contract.Value));

    private SkillRatingValue AdaptValue(int value) => value switch
    {
        1 => SkillRatingValue.Beginner,
        2 => SkillRatingValue.AdvancedBeginner,
        3 => SkillRatingValue.Expert,
        4 => SkillRatingValue.SepThoughtLeader,
        5 => SkillRatingValue.IndustryThoughtLeader,
        _ => throw new ArgumentOutOfRangeException(nameof(value))
    };
}
