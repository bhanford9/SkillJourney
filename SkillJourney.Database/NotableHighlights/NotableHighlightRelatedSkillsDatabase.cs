using SkillJourney.Database.SkillRatings;

namespace SkillJourney.Database.NotableHighlights;

internal interface INotableHighlightRelatedSkillsDatabase
{
    IReadOnlyList<INotableHighlightRelatedSkillEntry> NotableHighlightRelatedSkills { get; }

    void AddRelatedSkills(Guid notableHighlight, params Guid[] relatedSkills);
}

internal class NotableHighlightRelatedSkillsDatabase : INotableHighlightRelatedSkillsDatabase
{
    private readonly List<INotableHighlightRelatedSkillEntry> notableHighlightRelatedSkills = [];

    public NotableHighlightRelatedSkillsDatabase(ISkillRatingsDatabaseApi skillRatingsDatabaseApi)
    {
        var ratingValues = Enum.GetValues<SkillRatingValue>();
        var softwareSoftwareConfigManagementSkillValues = ratingValues
            .Select(x => skillRatingsDatabaseApi.GetSkillRating(
                "Software Engineering",
                "Engineering",
                "Software Configuration Management",
                x))
            .ToDictionary(x => (SkillRatingValue)x.Value, x => x);
        var softwareAnalysisAndRequirementsSkillValues = ratingValues
            .Select(x => skillRatingsDatabaseApi.GetSkillRating(
                "Software Engineering",
                "Engineering",
                "Analysis and Requirements",
                x))
            .ToDictionary(x => (SkillRatingValue)x.Value, x => x);
        var softwareDevelopmentSkillValues = ratingValues
            .Select(x => skillRatingsDatabaseApi.GetSkillRating(
                "Software Engineering",
                "Engineering",
                "Development",
                x))
            .ToDictionary(x => (SkillRatingValue)x.Value, x => x);
        var softwareArchitectureSkillValues = ratingValues
            .Select(x => skillRatingsDatabaseApi.GetSkillRating(
                "Software Engineering",
                "Engineering",
                "Architecture",
                x))
            .ToDictionary(x => (SkillRatingValue)x.Value, x => x);
        var softwareTestingSkillValues = ratingValues
            .Select(x => skillRatingsDatabaseApi.GetSkillRating(
                "Software Engineering",
                "Engineering",
                "Testing",
                x))
            .ToDictionary(x => (SkillRatingValue)x.Value, x => x);

        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("bd43f975-8b10-456e-921d-2c1c692a3017"),
            NotableHighlight = new("3f7e5a2b-9772-4ce4-8856-9c019a430b58"), // "learned new unit test framework"
            RelatedSkill = softwareTestingSkillValues[SkillRatingValue.Beginner].Id
        });
    }

    public IReadOnlyList<INotableHighlightRelatedSkillEntry> NotableHighlightRelatedSkills => notableHighlightRelatedSkills;

    public void AddRelatedSkills(Guid notableHighlight, params Guid[] relatedSkills)
    {
        notableHighlightRelatedSkills.AddRange(relatedSkills.Select(x => 
            new NotableHighlightRelatedSkillEntry
            {
                Id = Guid.NewGuid(),
                NotableHighlight = notableHighlight,
                RelatedSkill = x
            }));
    }
}
