namespace SkillJourney.Database.SkillFields;

public interface ISkillFieldsDatabase
{
    IReadOnlyList<ISkillFieldEntry> SkillFields { get; }
}

internal class SkillFieldsDatabase : ISkillFieldsDatabase
{
    public IReadOnlyList<ISkillFieldEntry> SkillFields =>
        [
        new SkillFieldEntry(new Guid("64591244-b2e6-4aca-beb7-3920508c12c0"), "Management"),
        new SkillFieldEntry(new Guid("8cd70bdc-0d02-47ca-a4a4-6767f68a928d"), "Engineering"),
        new SkillFieldEntry(new Guid("e6cde148-9388-4a38-b660-e1497cd1f8b6"), "Business"),
        new SkillFieldEntry(new Guid("0910134c-a4a7-4ddc-82e0-858d782fd781"), "Information Technology"), // no fields specified
        new SkillFieldEntry(new Guid("B6AF6A39-89A5-483C-8BFE-886D4BE9AC5F"), "UX Discipline"),
        new SkillFieldEntry(new Guid("BB638264-C748-4F9B-A685-74E4BB8230D6"), "CX & Consulting"),
        new SkillFieldEntry(new Guid("FA2C42A4-C1C2-44D3-8093-5B0A8FCEC5F3"), "Leadership")
        ];
}
