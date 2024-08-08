using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Management;
public interface IProcessEngineeringSkills : ISkillRatings;
internal class ProcessEngineeringSkills : SoftwareEngineeringManagementSkills, IProcessEngineeringSkills
{
    public ProcessEngineeringSkills(
        ISkillRatingNaming naming,
        IBusinessAreasDatabaseApi businessAreasApi,
        ISkillFieldsDatabaseApi skillFieldsApi,
        ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

    protected override string BeginnerDescription { get; } =
        "Working knowledge of a variety of processes/methodologies/practices.";
    protected override string AdvancedBeginnerDescription { get; } =
        "Demonstrated ability to select processes and practices for projects (at least three instances) and do minor tailoring to support project needs.";
    protected override string ExpertDescription { get; } =
        "Demonstrated ability to learn customer processes and map SEP activities to them. Wide variety of experiences with project practices and processes and able to expertly tailor them to individual project needs.";
    protected override string SepThoughtLeaderDescription { get; } =
        "Has broad influence on processes and practices used throughout the company. Evaluates alternative practices and processes for use at SEP. Trains others on process engineering, including client process consulting. Well connected to the software community as it pertains to process and practices.";
    protected override string IndustryThoughtLeaderDescription { get; } =
        "Sets practice direction for the company. Recognized as an expert in the software community in the area of processes and practices, influencing the future direction of the discipline.";
    
    protected override Guid BeginnerId { get; } = new("B8207854-45EB-4D2C-84C8-788C11CBA6BF");
    protected override Guid AdvancedBeginnerId { get; } = new("B0AFAC48-56C2-4E6E-A0B2-CE72C18031B0");
    protected override Guid ExpertId { get; } = new("3B46358C-04A4-4782-8C8E-2CEFBBFD53BC");
    protected override Guid SepThoughtLeaderId { get; } = new("9EB76E63-A368-4430-9F14-CE76409C0226");
    protected override Guid IndustryThoughtLeaderId { get; } = new("53EE6353-D7EF-4F79-A2A2-CE148EDD2874");

    protected override string SkillCategoryName => "Process Engineering";
}
