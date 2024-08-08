using SkillJourney.Database.TitlePermissionPermissions;
using SkillJourney.Database.UserPermissionPermissions;

namespace SkillJourney.Database.Permissions;
public interface IPermissionsDatabaseApi
{
    IPermissionEntry GetPermissionById(Guid id);
    IReadOnlyList<IPermissionEntry> GetAllPermissions();
    IPermissionEntry GetDevPermission();
    IReadOnlyList<IPermissionEntry> GetUserPermissions(Guid userId);
    IReadOnlyList<IPermissionEntry> GetTitlePermissions(Guid titleId);
    IReadOnlyCollection<IPermissionEntry> GetPermissions(Guid userId, Guid titleId);
    IPermissionEntry GetViewUserHighlightsPermission();
    IReadOnlyCollection<IPermissionEntry> UpdatePermissions(IEnumerable<(Guid Id, bool IsDeprecated)> permissions);
}

internal class PermissionsDatabaseApi : IPermissionsDatabaseApi
{
    private readonly IPermissionsDatabase database;
    private readonly IUserPermissionsDatabase userPermissionsDatabase;
    private readonly ITitlePermissionsDatabase titlePermissionsDatabase;

    public PermissionsDatabaseApi(
        IPermissionsDatabase database,
        IUserPermissionsDatabase userPermissionsDatabase,
        ITitlePermissionsDatabase titlePermissionsDatabase)
    {
        this.database = database;
        this.userPermissionsDatabase = userPermissionsDatabase;
        this.titlePermissionsDatabase = titlePermissionsDatabase;
    }

    public IPermissionEntry GetPermissionById(Guid id) => database.Permissions.First(x => x.Id == id);

    public IReadOnlyList<IPermissionEntry> GetAllPermissions() => database.Permissions.ToList();

    public IPermissionEntry GetDevPermission() => database.DevAccessPermission;

    public IPermissionEntry GetViewUserHighlightsPermission() => database.ViewUserHighlightsPermission;

    public IReadOnlyList<IPermissionEntry> GetUserPermissions(Guid userId) => userPermissionsDatabase.UserPermissions
        .Where(x => x.UserId == userId)
        .Join(database.Permissions, x => x.PermissionId, x => x.Id, (a, b) => b)
        .ToList();

    public IReadOnlyList<IPermissionEntry> GetTitlePermissions(Guid titleId) => titlePermissionsDatabase.TitlePermissions
        .Where(x => x.TitleId == titleId)
        .Join(database.Permissions, x => x.PermissionId, x => x.Id, (a, b) => b)
        .ToList();

    public IReadOnlyCollection<IPermissionEntry> GetPermissions(Guid userId, Guid titleId)
        => GetUserPermissions(userId).Concat(GetTitlePermissions(titleId)).ToList();

    public IReadOnlyCollection<IPermissionEntry> UpdatePermissions(IEnumerable<(Guid Id, bool IsDeprecated)> permissions)
    {
        var titleUpdates = database.Permissions.Join(permissions, x => x.Id, x => x.Id, (a, b) => (ToUpdate: a, Incoming: b));

        foreach (var update in titleUpdates)
        {
            update.ToUpdate.IsDeprecated = update.Incoming.IsDeprecated;
        }

        database.Permissions = titleUpdates.Select(x => x.ToUpdate).ToList();

        return database.Permissions;
    }
}
