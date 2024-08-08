using SkillJourney.Api.Shared.Contract.Permissions;

namespace SkillJourney.Api.Client.ApiClients;

public interface IPermissionsClient
{
    Task<IReadOnlyList<PermissionContract>> GetAllPermissions();
    Task<PermissionContract> GetDevUserPermission();
    Task<PermissionContract> GetViewUserHighlightsPermission();
    Task<IReadOnlyList<PermissionContract>> SavePermissions(IReadOnlyList<PermissionContract> permissions);
}

internal class PermissionsClient : ApiClient, IPermissionsClient
{
    public PermissionsClient(IServerConfiguration serverConfig, HttpClient httpClient) : base(serverConfig, httpClient) { }

    public async Task<PermissionContract> GetDevUserPermission()
        => await GetAsync<PermissionContract>("permission-devuser");

    public async Task<PermissionContract> GetViewUserHighlightsPermission()
        => await GetAsync<PermissionContract>("permission-ViewUserHighlightsPermission");

    public async Task<IReadOnlyList<PermissionContract>> GetAllPermissions()
        => await GetAsync<IReadOnlyList<PermissionContract>>("permissions-list");

    public async Task<IReadOnlyList<PermissionContract>> SavePermissions(IReadOnlyList<PermissionContract> permissions)
        => await PostAsync("permissions-update", permissions);
}
