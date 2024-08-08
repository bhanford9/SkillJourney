namespace SkillJourney.Database.SkillCategories;

public interface ISkillCategoriesDatabase
{
    IReadOnlyList<ISkillCategoryEntry> SkillCategories { get; }
}

internal class SkillCategoriesDatabase : ISkillCategoriesDatabase
{
    public IReadOnlyList<ISkillCategoryEntry> SkillCategories =>
        [
        new SkillCategoryEntry(new Guid("ec010518-69dd-45da-b034-9056b9895bac"), "Process Engineering"),
        new SkillCategoryEntry(new Guid("8aacd927-f9bd-4ef8-9e46-22fd20781eab"), "Project Management"),
        new SkillCategoryEntry(new Guid("280c3966-95ee-43ea-96d4-308e453f5ed7"), "Estimating & Proposing"),
        new SkillCategoryEntry(new Guid("79c6eb96-af51-4076-bf5b-0aa601f2d3da"), "Employee Development"),
        new SkillCategoryEntry(new Guid("fecec460-fd0e-4061-a46d-d689b6905bb4"), "Customer Relationship Management"),
        new SkillCategoryEntry(new Guid("1db9442f-f497-4818-a1d3-e67baf6358a9"), "Software Configuration Management"),
        new SkillCategoryEntry(new Guid("8B59D9A7-DFFA-49AE-9215-835A50D05BE4"), "Analysis and Requirements"),
        new SkillCategoryEntry(new Guid("46208717-ED47-407C-85CE-A865359F75B9"), "Development"),
        new SkillCategoryEntry(new Guid("9CD3BDEB-4D02-4B3B-9250-8A2BD4B42AB3"), "Architecture"),
        new SkillCategoryEntry(new Guid("6D9B2686-27F5-48AF-B34D-4D075E214D34"), "Testing"),
        new SkillCategoryEntry(new Guid("A1054327-4268-49B9-9933-8A0D84079211"), "Business Development"),
        new SkillCategoryEntry(new Guid("3A9FD8D9-8BD2-4D82-952F-20C2464C629D"), "Operations"),
        new SkillCategoryEntry(new Guid("6FA42129-146E-404F-868A-28FAD956C470"), "Organizational Development"),
        new SkillCategoryEntry(new Guid("9368bae5-db33-426a-9add-fa460ed3e9b8"), "Design Principles & Heuristics"),
        new SkillCategoryEntry(new Guid("101dbf9c-2c31-4b8e-b1c5-817d20729dba"), "Generative Research"),
        new SkillCategoryEntry(new Guid("180af518-09b3-4799-837a-537ede3ca72f"), "Evaluative Research"),
        new SkillCategoryEntry(new Guid("08c07e2d-4f08-4ba3-9301-efebe841523b"), "Analysis & Synthesis"),
        new SkillCategoryEntry(new Guid("91d6292e-19ec-4f44-a52d-0ee5211b9c17"), "Information Architecture & Systems Thinking"),
        new SkillCategoryEntry(new Guid("f3cbc4e4-80a4-4d1d-9827-4f32c4626b00"), "Interaction Design"),
        new SkillCategoryEntry(new Guid("829fd6a2-1a17-4e71-8c4c-05245634cc5c"), "User Interface Design"),
        new SkillCategoryEntry(new Guid("eb5183c6-a084-4f96-a0d2-d89ff7ebea59"), "Front-End Development"),
        new SkillCategoryEntry(new Guid("3fbab8c6-c968-4d6e-9e52-7258e67e8e04"), "Strategy & Process")
        ];
}
