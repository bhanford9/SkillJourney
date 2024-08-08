namespace SkillJourney.Database.OccupationalTitles;
public interface IOccupationalTitlesDatabase
{
    IReadOnlyList<IOccupationalTitleEntry> OccupationalTitles { get; }
    IOccupationalTitleEntry SkillJourneyDeveloper { get; }
    IOccupationalTitleEntry SoftwareEngineer1 { get; }
    IOccupationalTitleEntry SoftwareEngineer2 { get; }
    IOccupationalTitleEntry SeniorSoftwareEngineer { get; }
    IOccupationalTitleEntry LeadSoftwareEngineer1 { get; }
    IOccupationalTitleEntry LeadSoftwareEngineer2 { get; }
    IOccupationalTitleEntry DeliveryLead { get; }
    IOccupationalTitleEntry StaffSoftwareEngineer { get; }
    IOccupationalTitleEntry SoftwareProducer { get; }
    IOccupationalTitleEntry SeniorProductStrategist { get; }
    IOccupationalTitleEntry EngagementManager { get; }
    IOccupationalTitleEntry DirectoryOfSoftwareEngineering { get; }
    IOccupationalTitleEntry UxDesigner { get; }
    IOccupationalTitleEntry SeniorUxDesigner { get; }
}

internal class OccupationalTitlesDatabase : IOccupationalTitlesDatabase
{
    public IReadOnlyList<IOccupationalTitleEntry> OccupationalTitles => [
        SkillJourneyDeveloper,
        SoftwareEngineer1,
        SoftwareEngineer2,
        SeniorSoftwareEngineer,
        LeadSoftwareEngineer1,
        LeadSoftwareEngineer2,
        DeliveryLead,
        StaffSoftwareEngineer,
        SoftwareProducer,
        SeniorProductStrategist,
        EngagementManager,
        DirectoryOfSoftwareEngineering,
        UxDesigner,
        SeniorUxDesigner,
    ];

    public IOccupationalTitleEntry SkillJourneyDeveloper { get; } = new OccupationalTitleEntry(
        new Guid("b8b5e6e4-df94-4c4c-8d77-1a65fcfe03b8"),
        "Skill Journey Developer");

    public IOccupationalTitleEntry SoftwareEngineer1 { get; } = new OccupationalTitleEntry(
        new Guid("d87f99f7-40e2-46cb-b6fa-1d3f654c1a04"),
        "Software Engineer I");

    public IOccupationalTitleEntry SoftwareEngineer2 { get; } = new OccupationalTitleEntry(
        new Guid("c5d4f028-69c7-4c3f-a4d6-5940ef8f6845"),
        "Software Engineer II");

    public IOccupationalTitleEntry SeniorSoftwareEngineer { get; } = new OccupationalTitleEntry(
        new Guid("fc9b8b6c-8c49-40b2-9b07-9e601cd78243"),
        "Senior Software Engineer");

    public IOccupationalTitleEntry LeadSoftwareEngineer1 { get; } = new OccupationalTitleEntry(
        new Guid("d08b1859-5b89-43b6-8b7f-b29de5cf13c2"),
        "Lead Software Engineer I");

    public IOccupationalTitleEntry LeadSoftwareEngineer2 { get; } = new OccupationalTitleEntry(
        new Guid("4a374e29-4b68-4d44-93a0-12b02c1ac8b9"),
        "Lead Software Engineer II");

    public IOccupationalTitleEntry DeliveryLead { get; } = new OccupationalTitleEntry(
        new Guid("09d7e5f2-bf77-4e8f-b54c-2dc12c91a09b"),
        "Delivery Lead");

    public IOccupationalTitleEntry StaffSoftwareEngineer { get; } = new OccupationalTitleEntry(
        new Guid("2a367391-e4f3-4be7-93aa-f9a78aa2b1c1"),
        "Staff Software Engineer");

    public IOccupationalTitleEntry SoftwareProducer { get; } = new OccupationalTitleEntry(
        new Guid("a7f3f93c-f60f-4997-8c0a-5f59f3a94a8d"),
        "Software Producer");

    public IOccupationalTitleEntry SeniorProductStrategist { get; } = new OccupationalTitleEntry(
        new Guid("3e61a1c6-40c6-4c3b-aec5-78c27c9ef12c"),
        "Senior Product Strategist");

    public IOccupationalTitleEntry EngagementManager { get; } = new OccupationalTitleEntry(
        new Guid("a578e98e-e9fa-4e05-8379-23cb1e17f794"),
        "Engagement Manager");

    public IOccupationalTitleEntry DirectoryOfSoftwareEngineering { get; } = new OccupationalTitleEntry(
        new Guid("d92a69f4-bf77-42c8-b750-c68da5b760d0"),
        "Director of Software Engineering");

    public IOccupationalTitleEntry UxDesigner { get; } = new OccupationalTitleEntry(
        new Guid("6f123bba-bc84-4a9e-b39f-e5af8d0c74af"),
        "UX Designer");

    public IOccupationalTitleEntry SeniorUxDesigner { get; } = new OccupationalTitleEntry(
        new Guid("1a2a5c4f-5ab7-44f5-a03c-58eeabc7a54a"),
        "Senior UX Designer");
}

