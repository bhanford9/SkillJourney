using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering;
internal abstract class SoftwareEngineeringSkills : SkillRatings
{
    protected SoftwareEngineeringSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi)
    {
    }

    protected override string BusinessAreaName => "Software Engineering";
}
