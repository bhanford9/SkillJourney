using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Engineering;
public interface ISoftwareConfigurationManagementSkills : ISkillRatings;
internal class SoftwareConfigurationManagementSkills : SoftwareEngineeringEngineeringSkills, ISoftwareConfigurationManagementSkills
{
    public SoftwareConfigurationManagementSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string BeginnerDescription { get; } =
        "Awareness of and exposure to SCM practices and tools. Able to use the required tools and execute the specified SCM practices in production work.";
    protected override string AdvancedBeginnerDescription { get; } =
        "Demonstrated ability to implement and improve SCM tools and practices for projects. Competent with a core set of SCM tools and practices.";
    protected override string ExpertDescription { get; } =
        "Demonstrated ability to lead these activities for teams, selecting and implementing SCM practices/tools for a variety of projects. Tailors practices to the specific needs of projects and clients. Keeps up with best practices and emerging trends in this area. Coaches less experienced people in this area.";
    protected override string SepThoughtLeaderDescription { get; } =
        "Demonstrated mastery of SCM practices and tools in a wide variety of contexts (different types of projects, technologies, etc.) Active in the SCM community. A thought leader at SEP in this area.";
    protected override string IndustryThoughtLeaderDescription { get; } =
        "Recognized as a master of SCM by the software community. Has influence inside and outside the company on best practices and new techniques.";
    
    protected override Guid BeginnerId { get; } = new("fb66477c-f8d3-40d5-ae64-7e0ad6e10357");
    protected override Guid AdvancedBeginnerId { get; } = new("d67dbe42-34b1-4801-9315-f6f662684c35");
    protected override Guid ExpertId { get; } = new("b14625ff-c2ef-4649-8e6f-75993540a3f8");
    protected override Guid SepThoughtLeaderId { get; } = new("c816e6bf-77b5-480e-aae4-4818924c80dd");
    protected override Guid IndustryThoughtLeaderId { get; } = new("217884d5-9525-42c8-bad3-b0db79fb07bd");

    protected override string SkillCategoryName => "Software Configuration Management";
}