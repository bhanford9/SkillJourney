namespace SkillJourney.Models.BusinessAreas;

internal interface IBusinessAreaFactory
{
    IBusinessAreaModel CreateBusinessArea(Guid id, string name);
}

internal class BusinessAreaFactory : IBusinessAreaFactory
{
    public IBusinessAreaModel CreateBusinessArea(Guid id, string name)
        => new BusinessAreaModel(id, name);
}
