using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine;

public interface IRequestFactory
{
    ICanUserViewDevToolsRequest GetCanUserViewDevToolsRequest(IReadOnlyList<Guid> permissions);
    ICanUserViewProfilesRequest GetCanUserViewProfilesRequest(IReadOnlyList<Guid> permissions);
}

internal class RequestFactory : IRequestFactory
{
    public ICanUserViewDevToolsRequest GetCanUserViewDevToolsRequest(IReadOnlyList<Guid> permissions)
        => new CanUserViewDevToolsRequest() { Permissions = permissions };

    public ICanUserViewProfilesRequest GetCanUserViewProfilesRequest(IReadOnlyList<Guid> permissions)
        => new CanUserViewProfilesRequest() { Permissions = permissions };
}
