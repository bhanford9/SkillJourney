namespace SkillJourney.Api.Server.ContractBuilders;

public interface IContractBuilderProvider
{
    IBusinessAreaContractBuilder BusinessArea { get; }
    INotableHighlightContractBuilder NotableHighlight { get; }
    INotableHighlightRelatedSkillContractBuilder NotableHighlightRelatedSkill { get; }
    IPermissionContractBuilder Permission { get; }
    ISkillCategoryContractBuilder SkillCategory { get; }
    ISkillFieldContractBuilder SkillField { get; }
    ISkillRatingContractBuilder SkillRating { get; }
    IUserContractBuilder User { get; }
    IOccupationalTitleContractBuilder OccupationalTitle { get; }
}

public class ContractBuilderProvider : IContractBuilderProvider
{
    public ContractBuilderProvider(
        ISkillRatingContractBuilder skillRating,
        IBusinessAreaContractBuilder businessArea,
        ISkillFieldContractBuilder skillField,
        ISkillCategoryContractBuilder skillCategory,
        INotableHighlightContractBuilder notableHighlight,
        IUserContractBuilder user,
        IPermissionContractBuilder permission,
        INotableHighlightRelatedSkillContractBuilder notableHighlightRelatedSkill,
        IOccupationalTitleContractBuilder occupationalTitle)
    {
        SkillRating = skillRating;
        BusinessArea = businessArea;
        SkillField = skillField;
        SkillCategory = skillCategory;
        NotableHighlight = notableHighlight;
        NotableHighlightRelatedSkill = notableHighlightRelatedSkill;
        User = user;
        Permission = permission;
        OccupationalTitle = occupationalTitle;
    }

    public ISkillRatingContractBuilder SkillRating { get; }
    public IBusinessAreaContractBuilder BusinessArea { get; }
    public ISkillFieldContractBuilder SkillField { get; }
    public ISkillCategoryContractBuilder SkillCategory { get; }
    public INotableHighlightContractBuilder NotableHighlight { get; }
    public INotableHighlightRelatedSkillContractBuilder NotableHighlightRelatedSkill { get; }
    public IUserContractBuilder User { get; }
    public IPermissionContractBuilder Permission { get; }
    public IOccupationalTitleContractBuilder OccupationalTitle { get; }
}