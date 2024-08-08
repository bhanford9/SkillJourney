namespace SkillJourney.PermissionsEngine.Requests;
public interface IPermissionRequest
{
    IReadOnlyList<Guid> Permissions { get; init; }

    bool Equals(object? obj);
    int GetHashCode();
}

public abstract class PermissionRequest : IPermissionRequest
{
    public IReadOnlyList<Guid> Permissions { get; init; } = [];

    public override bool Equals(object? obj) => obj is not null && obj.GetType() == GetType();

    public override int GetHashCode() => GetType().GetHashCode();
}

