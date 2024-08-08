namespace SkillJourney.Database.UserPermissionPermissions;
public interface IUserPermissionEntry
{
    Guid UserId { get; set; }
    Guid PermissionId { get; set; }
}

internal class UserPermissionEntry : IUserPermissionEntry
{
    public UserPermissionEntry(Guid userId, Guid permissionId)
    {
        UserId = userId;
        PermissionId = permissionId;
    }

    public Guid UserId { get; set; }
    public Guid PermissionId { get; set; }
}
