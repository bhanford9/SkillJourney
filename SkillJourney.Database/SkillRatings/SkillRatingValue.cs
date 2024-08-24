namespace SkillJourney.Database.SkillRatings;
public enum SkillRatingValue
{
    Beginner = 1,
    AdvancedBeginner = 2,
    Expert = 3,
    SepThoughtLeader = 4,
    IndustryThoughtLeader = 5
}

internal static class SkillRatingValueUtils
{
    public static int Value(this SkillRatingValue value) => (int)value;
}
