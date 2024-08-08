using SkillJourney.Models.OccupationalTitles;
using SkillJourney.Models.Permissions;

namespace SkillJourney.Models.Users;
public interface IUserFactory
{
    IUserModel CreateUser(
        Guid id,
        string name,
        IOccupationalTitleModel occupationalTitle,
        IReadOnlyList<IPermissionModel> permissions);
}

internal class UserFactory : IUserFactory
{
    public IUserModel CreateUser(
        Guid id,
        string name,
        IOccupationalTitleModel occupationalTitle,
        IReadOnlyList<IPermissionModel> permissions)
        => new UserModel(id, name, occupationalTitle, permissions);
}
