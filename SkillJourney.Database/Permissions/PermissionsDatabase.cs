namespace SkillJourney.Database.Permissions;
public interface IPermissionsDatabase
{
    IReadOnlyList<IPermissionEntry> Permissions { get; set; }
    IPermissionEntry DeprecatedPermission { get; }
    IPermissionEntry DevAccessPermission { get; }
    IPermissionEntry ViewUserHighlightsPermission { get; }
    IPermissionEntry AddUserHighlightsPermission { get; }
    IPermissionEntry EditUserHighlightsPermission { get; }
}

internal class PermissionsDatabase : IPermissionsDatabase
{
    public PermissionsDatabase()
    {
        Permissions = [
            DevAccessPermission,
            DeprecatedPermission,
            ViewUserHighlightsPermission,
            AddUserHighlightsPermission,
            EditUserHighlightsPermission,
        ];
    }

    public IReadOnlyList<IPermissionEntry> Permissions { get; set; }

    // USE TO TEST PERMISSIONS THAT ARE DEPRECATED DO NOT TAKE AFFECT
    public IPermissionEntry DeprecatedPermission { get; } = new PermissionEntry(
        new Guid("68a45b19-c8f3-4092-9829-82b7b58ccba6"),
        "Deprecated")
    { IsDeprecated = true };

    // BYPASSES ALL PERMISSIONS AND GRANTS ACCESS TO ANY ACTION
    public IPermissionEntry DevAccessPermission { get; } = new PermissionEntry(
        new Guid("0d5e4d03-5478-4744-9d95-c3f7b480c7f8"),
        "Dev Access");

    // GRANTS ACCESS TO VIEWING THE LIST OF HIGHLIGHTS OF A USER (all users can see own highlights)
    public IPermissionEntry ViewUserHighlightsPermission { get; } = new PermissionEntry(
        new Guid("f12f8a70-8f56-4c3e-9734-1a5f8963a4a1"),
        "View User Notable Highlights");

    // GRANTS ACCESS TO ADDING NEW HIGHLIGHTS TO THE LIST OF HIGHLIGHTS OF A USER (all users can add to own highlights)
    public IPermissionEntry AddUserHighlightsPermission { get; } = new PermissionEntry(
        new Guid("7bc0ec75-01a7-4c1b-b172-80c802bc8f9a"),
        "Add User Notable Highlight");

    // GRANTS ACCESS TO EDIT EXISTING HIGHLIGHTS OF A USER (all users can edit own highlights)
    public IPermissionEntry EditUserHighlightsPermission { get; } = new PermissionEntry(
        new Guid("e9e0c547-3d29-4df8-a01b-0c87492dbe7c"),
        "Edit User Notable Highlight");


}
