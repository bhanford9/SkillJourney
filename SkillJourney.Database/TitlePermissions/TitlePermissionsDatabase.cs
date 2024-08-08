using SkillJourney.Database.OccupationalTitles;
using SkillJourney.Database.Permissions;

namespace SkillJourney.Database.TitlePermissionPermissions;
public interface ITitlePermissionsDatabase
{
    IReadOnlyList<ITitlePermissionEntry> TitlePermissions { get; }
}

internal class TitlePermissionsDatabase : ITitlePermissionsDatabase
{
    private List<ITitlePermissionEntry> titlePermissions = [];

    public TitlePermissionsDatabase(
        IOccupationalTitlesDatabase occupationalTitlesDatabase,
        IPermissionsDatabase permissionsDatabase)
    {        
        titlePermissions.AddRange(
            permissionsDatabase.Permissions.Select(
                x => new TitlePermissionEntry(occupationalTitlesDatabase.SkillJourneyDeveloper.Id, x.Id)));

        titlePermissions.Add(new TitlePermissionEntry(
            occupationalTitlesDatabase.EngagementManager.Id,
            permissionsDatabase.ViewUserHighlightsPermission.Id));
        titlePermissions.Add(new TitlePermissionEntry(
            occupationalTitlesDatabase.EngagementManager.Id,
            permissionsDatabase.AddUserHighlightsPermission.Id));
        titlePermissions.Add(new TitlePermissionEntry(
            occupationalTitlesDatabase.EngagementManager.Id,
            permissionsDatabase.EditUserHighlightsPermission.Id));
    }

    public IReadOnlyList<ITitlePermissionEntry> TitlePermissions => titlePermissions;
}
