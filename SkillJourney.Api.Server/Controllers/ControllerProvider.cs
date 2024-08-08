namespace SkillJourney.Api.Server.Controllers;

public interface IControllerProvider
{
    IBusinessAreaController BusinessArea { get; }
    INotableHighlightController NotableHighlight { get; }
    IPermissionController Permission { get; }
    ISkillCategoryController SkillCategory { get; }
    ISkillFieldController SkillField { get; }
    ISkillRatingController SkillRating { get; }
    IUserController User { get; }
    IOccupationalTitleController OccupationalTitle { get; }
}

public class ControllerProvider : IControllerProvider
{
    public ControllerProvider(
        ISkillRatingController skillRating,
        IBusinessAreaController businessArea,
        ISkillFieldController skillField,
        ISkillCategoryController skillCategory,
        INotableHighlightController notableHighligh,
        IUserController user,
        IPermissionController permission,
        IOccupationalTitleController occupationalTitle)
    {
        SkillRating = skillRating;
        BusinessArea = businessArea;
        SkillField = skillField;
        SkillCategory = skillCategory;
        NotableHighlight = notableHighligh;
        User = user;
        Permission = permission;
        OccupationalTitle = occupationalTitle;
    }

    public ISkillRatingController SkillRating { get; }
    public IBusinessAreaController BusinessArea { get; }
    public ISkillFieldController SkillField { get; }
    public ISkillCategoryController SkillCategory { get; }
    public INotableHighlightController NotableHighlight { get; }
    public IUserController User { get; }
    public IPermissionController Permission { get; }
    public IOccupationalTitleController OccupationalTitle { get; }
}
