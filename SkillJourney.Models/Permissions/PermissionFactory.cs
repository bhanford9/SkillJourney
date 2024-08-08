namespace SkillJourney.Models.Permissions;
public interface IPermissionFactory
{
    IPermissionModel CreatePermission(Guid id, string name, bool isDeprecated);
}

internal class PermissionFactory : IPermissionFactory
{
    public IPermissionModel CreatePermission(Guid id, string name, bool isDeprecated)
        => new PermissionModel(id, name, isDeprecated);
}
