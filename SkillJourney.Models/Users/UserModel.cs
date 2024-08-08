using SkillJourney.Models.NotableHighlights;
using SkillJourney.Models.OccupationalTitles;
using SkillJourney.Models.Permissions;

namespace SkillJourney.Models.Users;

public interface IUserModel
{
    Guid Id { get; set; }
    string Name { get; set; }
    IReadOnlyList<IPermissionModel> Permissions { get; set; }
    IReadOnlyList<INotableHighlightModel> Highlights { get; set; }
    IOccupationalTitleModel OccupationalTitle { get; set; }
}

internal class UserModel : IUserModel
{
    public UserModel(
        Guid id,
        string name,
        IOccupationalTitleModel occupationalTitle,
        IReadOnlyList<IPermissionModel> permissions)
    {
        Id = id;
        Name = name;
        OccupationalTitle = occupationalTitle;
        Permissions = permissions;
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IOccupationalTitleModel OccupationalTitle { get; set; }

    public IReadOnlyList<IPermissionModel> Permissions { get; set; }

    public IReadOnlyList<INotableHighlightModel> Highlights { get; set; } = [];
}
