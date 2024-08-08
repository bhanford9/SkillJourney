namespace SkillJourney.Models.BusinessAreas;

public interface IBusinessAreaModel
{
    Guid Id { get; }
    string Name { get; }
}

internal class BusinessAreaModel : IBusinessAreaModel
{
    public BusinessAreaModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }
}
