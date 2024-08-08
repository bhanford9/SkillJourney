using SkillJourney.Api.Shared.Contract.NotableHighlights;
using SkillJourney.Api.Shared.Contract.OccupationalTitles;
using SkillJourney.Api.Shared.Contract.Permissions;

namespace SkillJourney.Api.Shared.Contract.Users;

public record UserSubContract(Guid Id, string Name, Guid TitleId);

public record UserContract(
    Guid Id,
    string Name,
    OccupationalTitleContract OccupationalTitle,
    IReadOnlyList<NotableHighlightContract> Highlights,
    IReadOnlyList<PermissionContract> Permissions);
