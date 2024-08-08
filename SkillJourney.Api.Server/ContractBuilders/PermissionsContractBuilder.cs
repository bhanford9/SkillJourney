using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.Database.Permissions;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface IPermissionContractBuilder
{
    PermissionContract BuildContract(IPermissionEntry rating);
}

public class PermissionContractBuilder : IPermissionContractBuilder
{
    public PermissionContract BuildContract(IPermissionEntry rating)
        => new(rating.Id, rating.Name, rating.IsDeprecated);
}
