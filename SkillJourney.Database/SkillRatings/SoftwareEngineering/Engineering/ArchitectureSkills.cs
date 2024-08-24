using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Engineering;
public interface IArchitectureSkills : ISkillRatings;
internal class ArchitectureSkills : SoftwareEngineeringEngineeringSkills, IArchitectureSkills
{
    public ArchitectureSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string BeginnerDescription { get; } =
        "Familiarity with basic architecture concepts (i.e. best practices, patterns, etc.)";
    protected override string AdvancedBeginnerDescription { get; } =
        "Professional experience with the architecture and integration of small-scale applications and systems (not many moving parts, typically modest performance loads) as it pertains to the relevant job function (dev, test, etc.)";
    protected override string ExpertDescription { get; } =
        "Wide ranging, demonstrated experience architecting and integrating applications and systems, some professional exposure to large scale systems (lots of moving parts and/or multiple systems interacting together, heavy loads). Coaches less experienced people in this area.";
    protected override string SepThoughtLeaderDescription { get; } =
        "Demonstrated mastery of small and large-scale application and system architecture. Demonstrated capability to perform all types of design and architecture activities on a wide variety of system types. A thought leader at SEP in this area.";
    protected override string IndustryThoughtLeaderDescription { get; } =
        "Recognized as a master of software architecture by the community. A thought leader in the industry.";

    protected override Guid BeginnerId { get; } = new("1d4e7d9c-8a7d-4f6b-9c85-95fd1e6a3c5e");
    protected override Guid AdvancedBeginnerId { get; } = new("f2bfa2b6-b2e5-4d85-bf71-bb2a855b2b78");
    protected override Guid ExpertId { get; } = new("6f947b8d-6d3a-4f8c-b5c0-35b0a2d5f5b7");
    protected override Guid SepThoughtLeaderId { get; } = new("d2efac78-7529-4f92-9f7c-7b6cb6cf7d40");
    protected override Guid IndustryThoughtLeaderId { get; } = new("a7e1b6a9-2372-4c7e-918d-08fbe1bbf0e2");

    protected override string SkillCategoryName => "Architecture";
}
