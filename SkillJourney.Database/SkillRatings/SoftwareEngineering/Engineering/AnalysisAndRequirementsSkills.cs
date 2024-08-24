using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Engineering;
public interface IAnalysisAndRequirementsSkills : ISkillRatings;
internal class AnalysisAndRequirementsSkills : SoftwareEngineeringEngineeringSkills, IAnalysisAndRequirementsSkills
{
    public AnalysisAndRequirementsSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string BeginnerDescription { get; } =
        "Demonstrated capability to develop software and/or write test procedures against written requirements.";
    protected override string AdvancedBeginnerDescription { get; } =
        "Demonstrated capability to read and write software requirements. Can evaluate requirements for testability and suitability.";
    protected override string ExpertDescription { get; } =
        "2-5 years of project experience actively performing requirements and analysis activities. Experience with eliciting requirements from customers. They have demonstrated the ability to lead these activities as it pertains to the relevant job function (dev, test, etc.) Coaches less experienced people in this area. Competent with multiple models for requirements capture.";
    protected override string SepThoughtLeaderDescription { get; } =
        "5+ years of project experience actively performing requirements and analysis activities. In addition, they are actively networking with the relevant community in areas related to these skills. A thought leader within SEP in this area. Fluent with the impact of requirements in at least one regulated domain.";
    protected override string IndustryThoughtLeaderDescription { get; } =
        "10+ years of project experience actively performing requirements and analysis activities. In addition, they have attained recognition from the relevant community (associations, groups, etc.) for skills in this area.";
    
    protected override Guid BeginnerId { get; } = new("4a3b5d0e-c2f6-4a28-8d1e-6e8d2c47b3f9");
    protected override Guid AdvancedBeginnerId { get; } = new("b2c3d6f7-4e8a-5b1c-9d3e-7f1a8c2d6e4b");
    protected override Guid ExpertId { get; } = new("e9d7c3b0-5a1f-4d9e-8a2b-3f6c4d7e8a1b");
    protected override Guid SepThoughtLeaderId { get; } = new("7f2b8d9c-3e4a-5d6f-1a2b-9e7c3d4a5b8e");
    protected override Guid IndustryThoughtLeaderId { get; } = new("c4a2d6f8-3e7b-4d9c-1a5e-2f8b3c7d6a9e");

    protected override string SkillCategoryName => "Analysis and Requirements";
}
