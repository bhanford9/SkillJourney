using SkillJourney.Database.Users;

namespace SkillJourney.Database.NotableHighlights;
public interface INotableHighlightsDatabase
{
    IReadOnlyList<INotableHighlightEntry> NotableHighlights { get; }

    INotableHighlightEntry AddHighlight(
        Guid userId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence);
    void UpdateHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence);
}

internal class NotableHighlightsDatabase : INotableHighlightsDatabase
{
    private readonly List<INotableHighlightEntry> notableHighlights = [];
    

    public NotableHighlightsDatabase(IUsersDatabaseApi usersDatabaseApi)
    {
        notableHighlights.Add(new NotableHighlightEntry(
            new("3f7e5a2b-9772-4ce4-8856-9c019a430b58"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "learned new unit test framework",
            new DateTime(2022, 3, 19)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("9fa84c6f-03ea-4855-9e6f-3a66c2752962"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "learned new system test framework",
            new DateTime(2022, 4, 24)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("a624d3e9-579e-4d2f-9669-75132aac55e3"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "wrote manual test procedures",
            new DateTime(2022, 5, 12)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("660d122d-1bbd-4b0c-813a-dd457bfae3d9"),
            usersDatabaseApi.GetDevUser().Id,
            3,
            "built new integration test infrastructure",
            new DateTime(2022, 6, 2)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("d88356d1-b7e5-4c93-b9dc-0baee486643c"),
            usersDatabaseApi.GetDevUser().Id,
            1,
            "been developing user stories for 1 year on project",
            new DateTime(2023, 3, 20)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("f214cd43-3d91-45d9-a60e-c7eb13867556"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "created new dev tool",
            new DateTime(2022, 7, 28)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("700415d4-0656-4ca2-9c3d-60be33630d68"),
            usersDatabaseApi.GetDevUser().Id,
            3,
            "create new micro service",
            new DateTime(2023, 2, 8)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("124a8496-803a-4b39-a3da-bf1931f3faa6"),
            usersDatabaseApi.GetDevUser().Id,
            1,
            "wrote first SQL query",
            new DateTime(2022, 8, 12)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("8cd46476-55a6-45e3-adc6-6b8bc2038706"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "wrote first SQL migration",
            new DateTime(2022, 9, 9)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("f37f229e-3c51-4e0c-b553-de27a6a54c92"),
            usersDatabaseApi.GetDevUser().Id,
            6,
            "converted Relational DB to Document DB",
            new DateTime(2024, 1, 19)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("c15dea7c-6176-46a0-aa37-1df833e18cb9"),
            usersDatabaseApi.GetDevUser().Id,
            4,
            "implemented signal processing algorithm",
            new DateTime(2023, 7, 29)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("25634e95-a894-46d5-8e69-490b82e2a2cb"),
            usersDatabaseApi.GetDevUser().Id,
            5,
            "Rearchitected data structures to speed up performance by 40%",
            new DateTime(2023, 9, 4)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("5179b02b-6bfc-40d0-b836-2de1cffeb6b0"),
            usersDatabaseApi.GetDevUser().Id,
            7,
            "Built project skeleton for UI, API, Service and Database infrastructure",
            new DateTime(2024, 8, 14)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("f99f98e6-0ead-43d0-b86a-01b989fd80d6"),
            usersDatabaseApi.GetDevUser().Id,
            5,
            "Reorganized APIs to utilize asynchronous streaming of data",
            new DateTime(2023, 8, 2)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("dd4bcdb7-f26c-4d50-b8f7-667641a749d9"),
            usersDatabaseApi.GetDevUser().Id,
            2,
            "work with project owner to develop acceptance criteria",
            new DateTime(2022, 4, 1)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("21fbf51a-6d15-49cc-be24-f8520851bb06"),
            usersDatabaseApi.GetDevUser().Id,
            5,
            "work with SMEs to discover project goals and requirements",
            new DateTime(2023, 3, 10)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("c69647d8-4594-4632-b6fd-54eb1f826b4a"),
            usersDatabaseApi.GetDevUser().Id,
            6,
            "develop requirements tracking workbooks with client",
            new DateTime(2023, 8, 16)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("a3813e3e-62b0-4559-b1e1-c24022613ba0"),
            usersDatabaseApi.GetDevUser().Id,
            5,
            "added tracability from requirements to tests",
            new DateTime(2024, 2, 2)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("8398a177-65f6-4a28-9a23-13d5c7cfa2a6"),
            usersDatabaseApi.GetDevUser().Id,
            3,
            "added github action to run tests after project build",
            new DateTime(2023, 12, 14)));
        notableHighlights.Add(new NotableHighlightEntry(
            new("3585c14c-5a41-4008-84e6-6551604c3ed0"),
            usersDatabaseApi.GetDevUser().Id,
            4,
            "added azure pipeline to kickoff build and run tests for every pull request",
            new DateTime(2024, 4, 17)));
    }

    public IReadOnlyList<INotableHighlightEntry> NotableHighlights => notableHighlights;

    public INotableHighlightEntry AddHighlight(
        Guid userId,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence)
    {
        var entry = new NotableHighlightEntry(
            Guid.NewGuid(),
            userId,
            significanceRating,
            description,
            dateOfOccurrence);
        notableHighlights.Add(entry);
        return entry;
    }

    public void UpdateHighlight(
        Guid id,
        int significanceRating,
        string description,
        DateTime dateOfOccurrence)
    {
        var highlight = notableHighlights[notableHighlights.IndexOf(notableHighlights.First(x => x.Id.Equals(id)))];

        highlight.SignificanceRating = significanceRating;
        highlight.Description = description;
        highlight.DateOfOccurrence = dateOfOccurrence;
    }
}
