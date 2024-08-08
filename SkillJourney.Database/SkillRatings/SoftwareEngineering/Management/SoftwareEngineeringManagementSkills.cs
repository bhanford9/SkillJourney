using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Management;
internal abstract class SoftwareEngineeringManagementSkills : SoftwareEngineeringSkills
{
    public SoftwareEngineeringManagementSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
    : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string SkillFieldName => "Management";
}
