namespace SkillJourney.Database.TitlePermissionPermissions;
public interface ITitlePermissionEntry
{
    Guid TitleId { get; set; }
    Guid PermissionId { get; set; }
}

internal class TitlePermissionEntry : ITitlePermissionEntry
{
    public TitlePermissionEntry(Guid titleId, Guid permissionId)
    {
        TitleId = titleId;
        PermissionId = permissionId;
    }

    public Guid TitleId { get; set; }
    public Guid PermissionId { get; set; }
}
