using SkillJourney.Models.BusinessAreas;
using SkillJourney.Models.NotableHighlights;
using SkillJourney.Models.OccupationalTitles;
using SkillJourney.Models.Permissions;
using SkillJourney.Models.SkillCategories;
using SkillJourney.Models.SkillFields;
using SkillJourney.Models.SkillRatings;
using SkillJourney.Models.Users;
using SkillJourney.ViewModels.BusinessAreas;
using SkillJourney.ViewModels.DeveloperTools;
using SkillJourney.ViewModels.NotableHighlights;
using SkillJourney.ViewModels.OccupationalTitles;
using SkillJourney.ViewModels.Permissions;
using SkillJourney.ViewModels.SkillCategories;
using SkillJourney.ViewModels.SkillFields;
using SkillJourney.ViewModels.SkillRatings;
using SkillJourney.ViewModels.Users;

namespace SkillJourney.ViewModels;

public interface IViewModelFactory
{
    IBusinessAreaViewModel BuildBusinessArea(IBusinessAreaModel businessArea);
    INotableHighlightViewModel BuildNotableHighlight(INotableHighlightModel notableHighlight);
    IPermissionViewModel BuildPermission(IPermissionModel permission);
    IPermissionsListItemViewModel BuildPermissionsListItem(IPermissionModel permission);
    ISkillCategoryViewModel BuildSkillCategory(ISkillCategoryModel skillCategory);
    ISkillFieldViewModel BuildSkillField(ISkillFieldModel skillField);
    ISkillRatingViewModel BuildSkillRating(ISkillRatingModel skillRating);
    IOccupationalTitleViewModel BuildTitle(IOccupationalTitleModel title);
    IUserViewModel BuildUser(IUserModel user);
    Task<IUserViewModel> BuildUser(Guid user);
    IUserConfigListItemViewModel BuildUserConfigListItem(IUserViewModel user);
    IUserConfigListItemViewModel BuildUserConfigListItem(IUserModel user);
}
internal class ViewModelFactory : IViewModelFactory
{
    private readonly IUserService userService;

    public ViewModelFactory(IUserService userService)
    {
        this.userService = userService;
    }


    public ISkillRatingViewModel BuildSkillRating(ISkillRatingModel skillRating)
        => new SkillRatingViewModel(skillRating, this);

    public IBusinessAreaViewModel BuildBusinessArea(IBusinessAreaModel businessArea)
        => new BusinessAreaViewModel(businessArea);

    public ISkillFieldViewModel BuildSkillField(ISkillFieldModel skillField)
        => new SkillFieldViewModel(skillField);

    public ISkillCategoryViewModel BuildSkillCategory(ISkillCategoryModel skillCategory)
        => new SkillCategoryViewModel(skillCategory);

    public INotableHighlightViewModel BuildNotableHighlight(INotableHighlightModel notableHighlight)
        => new NotableHighlightViewModel(notableHighlight, this);

    public IUserViewModel BuildUser(IUserModel user)
        => new UserViewModel(user, this);

    public async Task<IUserViewModel> BuildUser(Guid user)
        => new UserViewModel(await userService.GetExistingUser(user), this);

    public IPermissionViewModel BuildPermission(IPermissionModel permission)
        => new PermissionViewModel(permission);

    public IOccupationalTitleViewModel BuildTitle(IOccupationalTitleModel title)
        => new OccupationalTitleViewModel(title);

    public IUserConfigListItemViewModel BuildUserConfigListItem(IUserViewModel user)
        => new UserConfigListItemViewModel(user);

    public IUserConfigListItemViewModel BuildUserConfigListItem(IUserModel user)
        => new UserConfigListItemViewModel(BuildUser(user));

    public IPermissionsListItemViewModel BuildPermissionsListItem(IPermissionModel permission)
        => new PermissionsListItemViewModel(BuildPermission(permission));
}
