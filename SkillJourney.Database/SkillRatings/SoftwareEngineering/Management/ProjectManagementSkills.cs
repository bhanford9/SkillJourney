using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;

namespace SkillJourney.Database.SkillRatings.SoftwareEngineering.Management
{
    public interface IProjectManagementSkills : ISkillRatings;
    internal class ProjectManagementSkills : SoftwareEngineeringManagementSkills, IProjectManagementSkills
    {
        public ProjectManagementSkills(
            ISkillRatingNaming naming,
            IBusinessAreasDatabaseApi businessAreasApi,
            ISkillFieldsDatabaseApi skillFieldsApi,
            ISkillCategoriesDatabaseApi skillCategoriesApi)
        : base(naming, businessAreasApi, skillFieldsApi, skillCategoriesApi) { }

        protected override string BeginnerDescription { get; } = "Aware of the responsibilities associated with project management and exposed to their execution. Some handling of delegated responsibilities in this area.";
        protected override string AdvancedBeginnerDescription { get; } = "Demonstrated ability to handle project management tasks for small projects (typically less than four total people) as well as minimally dynamic projects. Note that this management could happen as a sub-team of a larger team as long as the team was of an appropriate size and project management tasks were being performed.";
        protected override string ExpertDescription { get; } = "Demonstrated ability to handle project management tasks for a medium (typically five to nine people) as well as moderately dynamic projects. Can coach less experienced or aspiring project managers. Exposure to a range of project situations such as highly regulated, high urgency, politically charged projects, etc.";
        protected override string SepThoughtLeaderDescription { get; } = "Demonstrated ability to handle project management tasks for large (ten or more people) as well as highly dynamic projects. Can define company-wide best practices for managing projects. Experience with a broad variety of project experiences. Connected to the project management community.";
        protected override string IndustryThoughtLeaderDescription { get; } = "Exceptional demonstrated project management capabilities across a broad variety of situations. Recognized as an expert in the project management community.";

        protected override Guid BeginnerId { get; } = new("5961278f-043b-4e5c-a3d6-907821e2b8c7");
        protected override Guid AdvancedBeginnerId { get; } = new("6842157d-390a-4e1c-b5f6-973280b2d5e9");
        protected override Guid ExpertId { get; } = new("8239465b-70f4-4d6c-a1e7-509238e2b0c6");
        protected override Guid SepThoughtLeaderId { get; } = new("9f5a3d7e-81df-4ee6-b3ca-ffdcedfaebda");
        protected override Guid IndustryThoughtLeaderId { get; } = new("5cbbbcf7-ecfe-4a8c-bdcc-d1dbfdabbfde");

        protected override string SkillCategoryName => "Project Management";
    }
}