namespace SkillJourney.Database.BusinessAreas;

public interface IBusinessAreasDatabase
{
    IReadOnlyList<IBusinessAreaEntry> BusinessAreas { get; }
}

internal class BusinessAreasDatabase : IBusinessAreasDatabase
{
    public IReadOnlyList<IBusinessAreaEntry> BusinessAreas => [
        new BusinessAreaEntry(
            new Guid("26759843-0b9c-4d8a-a3e7-f52610f0c5b4"),
            "Software Engineering"),

        new BusinessAreaEntry(
            new Guid("8e6d379c-1ee8-4b3a-bdff-eaeaebfaacdc"),
            "Information Technology"),

        new BusinessAreaEntry(
            new Guid("0cbfdcc7-eced-4d6f-bfda-adcfdddeefdf"),
            "User Experience")];
}
