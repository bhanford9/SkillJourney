namespace SkillJourney.Database.UserPermissionPermissions;
public interface IUserPermissionsDatabaseApi
{
    IUserPermissionEntry GetUserPermissionById(Guid userId, Guid permissionId);
    IReadOnlyList<IUserPermissionEntry> GetAllUserPermissions();
}

internal class UserPermissionsDatabaseApi : IUserPermissionsDatabaseApi
{
    private readonly IUserPermissionsDatabase database;

    public UserPermissionsDatabaseApi(IUserPermissionsDatabase database)
    {
        this.database = database;
    }

    public IUserPermissionEntry GetUserPermissionById(Guid userId, Guid permissionId)
        => database.UserPermissions.First(x => x.UserId == userId && x.PermissionId == permissionId);

    public IReadOnlyList<IUserPermissionEntry> GetAllUserPermissions() => database.UserPermissions.ToList();
}
