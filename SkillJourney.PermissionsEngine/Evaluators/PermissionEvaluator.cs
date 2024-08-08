using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine.Evaluators;

public interface IPermissionEvaluator
{
    bool CanEvaluate(IPermissionRequest request);
    Task<bool> Evaluate(IPermissionRequest request);
}

public abstract class PermissionEvaluator<TRequest> : IPermissionEvaluator where TRequest : IPermissionRequest
{
    protected readonly IPermissionsClient permissionsClient;

    public PermissionEvaluator(IPermissionsClient permissionsClient)
    {
        this.permissionsClient = permissionsClient;
    }

    public bool CanEvaluate(IPermissionRequest request) => request is TRequest;

    public async Task<bool> Evaluate(IPermissionRequest request)
    {
        // go to database every-time (don't cache) in case the permission has been newly deprecated
        var permission = await GetPermission();
        return await ((!permission.IsDeprecated && request is TRequest r)
            ? InternalEvaluate(r, permission)
            : Task.FromResult(false));
    }

    protected abstract Task<bool> InternalEvaluate(TRequest request, PermissionContract permission);

    protected abstract Task<PermissionContract> GetPermission();
}

public abstract class SimplePermissionEvaluator<TRequest> : PermissionEvaluator<TRequest> where TRequest : IPermissionRequest
{
    protected SimplePermissionEvaluator(IPermissionsClient permissionsClient) : base(permissionsClient)
    {
    }

    protected override Task<bool> InternalEvaluate(TRequest request, PermissionContract permission)
        => Task.FromResult(request.Permissions.Contains(permission.Id));
}
