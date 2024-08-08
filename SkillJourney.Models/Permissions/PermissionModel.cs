namespace SkillJourney.Models.Permissions;

public interface IPermissionModel
{
    Guid Id { get; set; }
    string Name { get; set; }
    bool IsDeprecated { get; set; }
}

internal class PermissionModel : IPermissionModel
{
    public PermissionModel(Guid id, string name, bool isDeprecated)
    {
        Id = id;
        Name = name;
        IsDeprecated = isDeprecated;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeprecated { get; set; } = false;
}
