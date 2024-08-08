using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine.Evaluators;

public interface ICanViewDevToolsEvaluator : IPermissionEvaluator;
internal class CanViewDevToolsEvaluator : SimplePermissionEvaluator<CanUserViewDevToolsRequest>, ICanViewDevToolsEvaluator
{
    public CanViewDevToolsEvaluator(IPermissionsClient permissionsClient) : base(permissionsClient)
    {
    }

    protected override Task<PermissionContract> GetPermission()
        => permissionsClient.GetDevUserPermission();
}
