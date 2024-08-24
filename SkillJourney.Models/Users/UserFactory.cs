using SkillJourney.Models.NotableHighlights;
using SkillJourney.Models.OccupationalTitles;
using SkillJourney.Models.Permissions;

namespace SkillJourney.Models.Users;
public interface IUserFactory
{
    IUserModel CreateUser(
        Guid id,
        string name,
        IOccupationalTitleModel occupationalTitle,
        IReadOnlyList<IPermissionModel> permissions,
        IReadOnlyList<INotableHighlightModel> highlights);
}

internal class UserFactory : IUserFactory
{
    public IUserModel CreateUser(
        Guid id,
        string name,
        IOccupationalTitleModel occupationalTitle,
        IReadOnlyList<IPermissionModel> permissions,
        IReadOnlyList<INotableHighlightModel> highlights)
        => new UserModel(id, name, occupationalTitle, permissions, highlights);
}
