using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Engineering;
public interface IDevelopmentSkills : ISkillRatings;
internal class DevelopmentSkills : SoftwareEngineeringEngineeringSkills, IDevelopmentSkills
{
    public DevelopmentSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string BeginnerDescription { get; } =
        "Demonstrated ability to do basic development work in at least one area.";
    protected override string AdvancedBeginnerDescription { get; } =
        "Demonstrated ability (typically 12 to 18 months of experience ) to work independently and develop professional quality work in at least one area. Demonstrated competence performing supporting activities such as low level design, peer review, and unit testing.";
    protected override string ExpertDescription { get; } =
        "Professional experience in at least three development areas or deep knowledge, experience, and breadth in one (potentially demonstrated by external certification). Demonstrated ability to perform design and design review activities for systems. Coaches less experienced people in this area.";
    protected override string SepThoughtLeaderDescription { get; } =
        "Expert with two or more development areas and strong working knowledge of others. In addition, they are actively networking with the software community in areas related to these skills.";
    protected override string IndustryThoughtLeaderDescription { get; } =
        "Recognized as a master in development by the software community. Has influence inside and outside the company on best practices and new techniques. 10+ years experience actively performing development activities.";

    protected override Guid BeginnerId { get; } = new("e4b1c8d2-7f0e-4a2d-8d1a-7f5c3e7e1c68");
    protected override Guid AdvancedBeginnerId { get; } = new("f7a5e4d1-3b2c-4d9b-8f36-2d1e7b9c0c2a");
    protected override Guid ExpertId { get; } = new("c6f8d4e0-1d3b-45e2-87a3-19b4a6f7e5d6");
    protected override Guid SepThoughtLeaderId { get; } = new("b8c5e2d9-4a7b-4c1a-9f5e-3d7e8a9b0c3d");
    protected override Guid IndustryThoughtLeaderId { get; } = new("a2e9d1c5-8d4f-4b6a-9c2e-5b8a7c9d4f1e");

    protected override string SkillCategoryName => "Development";
}