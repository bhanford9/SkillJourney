namespace SkillJourney.Database.TitlePermissionPermissions;
public interface ITitlePermissionsDatabaseApi
{
    ITitlePermissionEntry GetTitlePermissionById(Guid titleId, Guid permissionId);
    IReadOnlyList<ITitlePermissionEntry> GetAllTitlePermissions();
}

internal class TitlePermissionsDatabaseApi : ITitlePermissionsDatabaseApi
{
    private readonly ITitlePermissionsDatabase database;

    public TitlePermissionsDatabaseApi(ITitlePermissionsDatabase database)
    {
        this.database = database;
    }

    public ITitlePermissionEntry GetTitlePermissionById(Guid titleId, Guid permissionId)
        => database.TitlePermissions.First(x => x.TitleId == titleId && x.PermissionId == permissionId);

    public IReadOnlyList<ITitlePermissionEntry> GetAllTitlePermissions() => database.TitlePermissions.ToList();
}
