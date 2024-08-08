using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings;

public interface ISkillRatings
{
    IEnumerable<ISkillRatingEntry> Skills { get; }
}

internal abstract class SkillRatings : ISkillRatings
{
    private readonly ISkillRatingNaming naming;
    private readonly IBusinessAreasDatabaseApi businessAreasApi;
    private readonly ISkillFieldsDatabaseApi skillFieldsApi;
    private readonly ISkillCategoriesDatabaseApi skillCategoriesApi;
    private static readonly string seAreaName = "Software Engineering";
    private static readonly string itAreaName = "Information Technology";
    private static readonly string uxAreaName = "User Experience";

    public SkillRatings(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
    {
        this.naming = naming;
        this.businessAreasApi = businessAreasApi;
        this.skillFieldsApi = skillFieldsApi;
        this.skillCategoriesApi = skillCategoriesApi;
    }

    protected abstract string BusinessAreaName { get; }
    protected abstract string SkillFieldName { get; }
    protected abstract string SkillCategoryName { get; }
    protected abstract string BeginnerDescription { get; }
    protected abstract string AdvancedBeginnerDescription { get; }
    protected abstract string ExpertDescription { get; }
    protected abstract string SepThoughtLeaderDescription { get; }
    protected abstract string IndustryThoughtLeaderDescription { get; }
    protected abstract Guid BeginnerId { get; }
    protected abstract Guid AdvancedBeginnerId { get; }
    protected abstract Guid ExpertId { get; }
    protected abstract Guid SepThoughtLeaderId { get; }
    protected abstract Guid IndustryThoughtLeaderId { get; }

    public IEnumerable<ISkillRatingEntry> Skills =>
        [
            new SkillRatingEntry(
                BeginnerId,
                naming.GetBeginner(SkillCategoryName),
                BeginnerDescription,
                businessAreasApi.GetIdByName(BusinessAreaName),
                skillFieldsApi.GetIdByName(SkillFieldName),
                skillCategoriesApi.GetIdByName(SkillCategoryName),
                SkillRatingValue.Beginner.Value(),
                false),
            new SkillRatingEntry(
                AdvancedBeginnerId,
                naming.GetAdvancedBeginner(SkillCategoryName),
                AdvancedBeginnerDescription,
                businessAreasApi.GetIdByName(BusinessAreaName),
                skillFieldsApi.GetIdByName(SkillFieldName),
                skillCategoriesApi.GetIdByName(SkillCategoryName),
                SkillRatingValue.AdvancedBeginner.Value(),
                false),
            new SkillRatingEntry(
                ExpertId,
                naming.GetExpert(SkillCategoryName),
                ExpertDescription,
                businessAreasApi.GetIdByName(BusinessAreaName),
                skillFieldsApi.GetIdByName(SkillFieldName),
                skillCategoriesApi.GetIdByName(SkillCategoryName),
                SkillRatingValue.Expert.Value(),
                false),
            new SkillRatingEntry(
                SepThoughtLeaderId,
                naming.GetSepThoughtLeader(SkillCategoryName),
                SepThoughtLeaderDescription,
                businessAreasApi.GetIdByName(BusinessAreaName),
                skillFieldsApi.GetIdByName(SkillFieldName),
                skillCategoriesApi.GetIdByName(SkillCategoryName),
                SkillRatingValue.SepThoughtLeader.Value(),
                false),
            new SkillRatingEntry(
                IndustryThoughtLeaderId,
                naming.GetIndustryThoughtLeader(SkillCategoryName),
                IndustryThoughtLeaderDescription,
                businessAreasApi.GetIdByName(BusinessAreaName),
                skillFieldsApi.GetIdByName(SkillFieldName),
                skillCategoriesApi.GetIdByName(SkillCategoryName),
                SkillRatingValue.IndustryThoughtLeader.Value(),
                false),
        ];
}
