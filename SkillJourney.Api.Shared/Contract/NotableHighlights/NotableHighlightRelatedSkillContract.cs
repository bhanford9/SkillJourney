using SkillJourney.Api.Shared.Contract.SkillRatings;

namespace SkillJourney.Api.Shared.Contract.NotableHighlights;

public record NotableHighlightRelatedSkillSubContract(Guid Id, Guid SkillRating);
public record NotableHighlightRelatedSkillContract(Guid Id, SkillRatingContract SkillRating);
