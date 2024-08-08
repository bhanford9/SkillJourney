using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Api.Shared.Contract.OccupationalTitles;
using SkillJourney.Api.Shared.Contract.Permissions;
using SkillJourney.Api.Shared.Contract.Users;
using SkillJourney.Database.Users;

namespace SkillJourney.Api.Server.ContractBuilders;

public interface IUserContractBuilder
{
    UserContract BuildContract(
        IUserEntry user,
        OccupationalTitleContract occupationalTitle,
        IReadOnlyList<NotableHighlightContract> highlights,
        IReadOnlyList<PermissionContract> permissions);
}

public class UserContractBuilder : IUserContractBuilder
{
    public UserContract BuildContract(
        IUserEntry user,
        OccupationalTitleContract occupationalTitle,
        IReadOnlyList<NotableHighlightContract> highlights,
        IReadOnlyList<PermissionContract> permissions) => new(
            user.Id,
            user.Name,
            occupationalTitle,
            highlights,
            permissions);
}
