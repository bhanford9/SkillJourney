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
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("5a0702c6-65a3-4960-bce8-d50b4a63a511"),
            NotableHighlight = new("9fa84c6f-03ea-4855-9e6f-3a66c2752962"), // "learned new system test framework"
            RelatedSkill = softwareTestingSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("8f511e8b-a060-48e7-a8c2-262d7b7f95ef"),
            NotableHighlight = new("a624d3e9-579e-4d2f-9669-75132aac55e3"), // "wrote manual test procedures"
            RelatedSkill = softwareTestingSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("32e1a6b8-18d8-4d3e-919b-cc7b72999815"),
            NotableHighlight = new("660d122d-1bbd-4b0c-813a-dd457bfae3d9"), // "built new integration test infrastructure"
            RelatedSkill = softwareTestingSkillValues[SkillRatingValue.AdvancedBeginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("355dde88-12ac-4a9a-9f37-8d51f9c4a92b"),
            NotableHighlight = new("d88356d1-b7e5-4c93-b9dc-0baee486643c"), // "been developing user stories for 1 year on project"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("da9ee618-e5fa-4777-a4fc-dc654a1da65a"),
            NotableHighlight = new("f214cd43-3d91-45d9-a60e-c7eb13867556"), // "created new dev tool"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("88dc0f3e-eda2-4fbf-abfb-0fa847df936c"),
            NotableHighlight = new("700415d4-0656-4ca2-9c3d-60be33630d68"), // "create new micro service"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.AdvancedBeginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("5c6d3537-5e14-4c5e-9e49-0003f2db66b9"),
            NotableHighlight = new("124a8496-803a-4b39-a3da-bf1931f3faa6"), // "wrote first SQL query"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("87e0f79c-c100-4e72-add3-28c618871e4d"),
            NotableHighlight = new("8cd46476-55a6-45e3-adc6-6b8bc2038706"), // "wrote first SQL migration"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("cd5d97cc-8d6c-4609-9c11-edc9ee823a3f"),
            NotableHighlight = new("f37f229e-3c51-4e0c-b553-de27a6a54c92"), // "converted Relational DB to Document DB"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("861ab8e1-2478-4118-990c-591109c6d692"),
            NotableHighlight = new("c15dea7c-6176-46a0-aa37-1df833e18cb9"), // "implemented signal processing algorithm"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("9f9d10a2-4ac4-402a-aaeb-d27a4aa447d1"),
            NotableHighlight = new("25634e95-a894-46d5-8e69-490b82e2a2cb"), // "rearchitected data structures to speed up performance by 40%"
            RelatedSkill = softwareDevelopmentSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("5eabb357-8fbe-4363-963f-082bd5788423"),
            NotableHighlight = new("5179b02b-6bfc-40d0-b836-2de1cffeb6b0"), // "Built project skeleton for UI, API, Service and Database infrastructure"
            RelatedSkill = softwareArchitectureSkillValues[SkillRatingValue.SepThoughtLeader].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("e067ecd9-5838-4bb9-ac2b-4ebc71781f70"),
            NotableHighlight = new("f99f98e6-0ead-43d0-b86a-01b989fd80d6"), // "Reorganized APIs to utilize asynchronous streaming of data"
            RelatedSkill = softwareArchitectureSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("211ec619-02d1-4def-9f34-d10495bf3274"),
            NotableHighlight = new("dd4bcdb7-f26c-4d50-b8f7-667641a749d9"), // "work with project owner to develop acceptance criteria"
            RelatedSkill = softwareAnalysisAndRequirementsSkillValues[SkillRatingValue.Beginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("23b8c388-bc29-4320-8b1e-b6d855823e46"),
            NotableHighlight = new("21fbf51a-6d15-49cc-be24-f8520851bb06"), // "work with SMEs to discover project goals and requirements"
            RelatedSkill = softwareAnalysisAndRequirementsSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("014a6f8f-c03d-4077-80a1-7d506ce45c7a"),
            NotableHighlight = new("c69647d8-4594-4632-b6fd-54eb1f826b4a"), // "develop requirements tracking workbooks with client"
            RelatedSkill = softwareAnalysisAndRequirementsSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("03d20a0a-ae04-45ca-8ea4-b7b383fa73b2"),
            NotableHighlight = new("a3813e3e-62b0-4559-b1e1-c24022613ba0"), // "added tracability from requirements to tests"
            RelatedSkill = softwareAnalysisAndRequirementsSkillValues[SkillRatingValue.Expert].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("9b8f0837-c6e0-4828-b562-b0cc52b80598"),
            NotableHighlight = new("8398a177-65f6-4a28-9a23-13d5c7cfa2a6"), // "added github action to run tests after project build"
            RelatedSkill = softwareAnalysisAndRequirementsSkillValues[SkillRatingValue.AdvancedBeginner].Id
        });
        notableHighlightRelatedSkills.Add(new NotableHighlightRelatedSkillEntry()
        {
            Id = new("47af3d97-5503-4efd-9e28-2a880b042af3"),
            NotableHighlight = new("3585c14c-5a41-4008-84e6-6551604c3ed0"), // "added azure pipeline to kickoff build and run tests for every pull request"
            RelatedSkill = softwareAnalysisAndRequirementsSkillValues[SkillRatingValue.Expert].Id
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
