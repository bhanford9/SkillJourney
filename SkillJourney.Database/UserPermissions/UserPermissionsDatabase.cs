using SkillJourney.Database.Permissions;
using SkillJourney.Database.Users;

namespace SkillJourney.Database.UserPermissionPermissions;
public interface IUserPermissionsDatabase
{
    IReadOnlyList<IUserPermissionEntry> UserPermissions { get; }
}

internal class UserPermissionsDatabase : IUserPermissionsDatabase
{
    private List<IUserPermissionEntry> userPermissions = [];
    public UserPermissionsDatabase(IUsersDatabase usersDatabase, IPermissionsDatabase permissionsDatabase)
    {
        // this is an example if we wanted to give a specific user a specific permission
        //userPermissions.Add(new UserPermissionEntry(
        //    usersDatabase.DevUser.Id,
        //    permissionsDatabase.DevAccessPermission.Id));
    }

    public IReadOnlyList<IUserPermissionEntry> UserPermissions => userPermissions;
}
