using SkillJourney.Api.Client.ApiClients;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine.Evaluators;
public interface ICanViewProfilesEvaluator : IPermissionEvaluator;
internal class CanViewProfilesEvaluator : SimplePermissionEvaluator<CanUserViewProfilesRequest>, ICanViewProfilesEvaluator
{
    public CanViewProfilesEvaluator(IPermissionsClient permissionsClient) : base(permissionsClient)
    {
    }

    protected override Task<PermissionContract> GetPermission()
        => permissionsClient.GetViewUserHighlightsPermission();
}
