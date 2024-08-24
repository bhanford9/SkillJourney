using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Engineering;
internal abstract class SoftwareEngineeringEngineeringSkills : SoftwareEngineeringSkills
{
    public SoftwareEngineeringEngineeringSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
    : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string SkillFieldName => "Engineering";
}