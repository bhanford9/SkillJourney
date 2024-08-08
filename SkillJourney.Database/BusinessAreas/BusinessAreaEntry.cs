namespace SkillJourney.Database.BusinessAreas;

public interface IBusinessAreaEntry
{
    Guid Id { get; set; }
    string Name { get; set; }
}

internal class BusinessAreaEntry : IBusinessAreaEntry
{
    public BusinessAreaEntry(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
