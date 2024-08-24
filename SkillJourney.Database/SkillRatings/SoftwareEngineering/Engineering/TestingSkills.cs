using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Engineering;
public interface ITestingSkills : ISkillRatings;
internal class TestingSkills : SoftwareEngineeringEngineeringSkills, ITestingSkills
{
    public TestingSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string BeginnerDescription { get; } =
        "Demonstrated ability to understand and execute written software test procedures.";
    protected override string AdvancedBeginnerDescription { get; } =
        "Demonstrated ability to formulate test cases and test procedures, with understanding of requirements and traceability.";
    protected override string ExpertDescription { get; } =
        "Demonstrated ability to formulate a test plan and select appropriate test methods for a product. This includes partitioning test procedures based upon system features and requirements. Knowledge of testing best practices and ability to apply them. Competent developing automated test scripts. Coaches less experienced people in this area.";
    protected override string SepThoughtLeaderDescription { get; } =
        "Mastery of software testing methods and technologies. Active participation within the software community in areas related to testing skills. Recognition as a thought leader within SEP in this area.";
    protected override string IndustryThoughtLeaderDescription { get; } =
        "Recognized as a master in testing by the software community. Has influence inside and outside the company on best practices and new techniques. 10+ years of project experience actively performing software testing and verification activities.";
    
    protected override Guid BeginnerId { get; } = new("80ac6695-1741-4858-8294-8af889ce3162");
    protected override Guid AdvancedBeginnerId { get; } = new("7828ddb1-2e2d-436f-bc0d-74cd33db9b59");
    protected override Guid ExpertId { get; } = new("30969a9f-98be-4ac7-80de-3811cf6bbf47");
    protected override Guid SepThoughtLeaderId { get; } = new("075076d5-7da9-42b1-8b02-3236137b18e6");
    protected override Guid IndustryThoughtLeaderId { get; } = new("feae44cc-bad3-4389-a18a-7f5820318a49");

    protected override string SkillCategoryName => "Testing";
}