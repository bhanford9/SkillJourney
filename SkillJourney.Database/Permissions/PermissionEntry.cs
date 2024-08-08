namespace SkillJourney.Database.Permissions;
public interface IPermissionEntry
{
    Guid Id { get; set; }
    string Name { get; set; }
    bool IsDeprecated { get; set; }
}

internal class PermissionEntry : IPermissionEntry
{
    public PermissionEntry(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeprecated { get; set; }
}
