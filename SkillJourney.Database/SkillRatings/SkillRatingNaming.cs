namespace SkillJourney.Database.SkillRatings;

internal interface ISkillRatingNaming
{
    string GetAdvancedBeginner(string skillDiscipline);
    string GetBeginner(string skillDiscipline);
    string GetExpert(string skillDiscipline);
    string GetIndustryThoughtLeader(string skillDiscipline);
    string GetSepThoughtLeader(string skillDiscipline);
}

internal class SkillRatingNaming : ISkillRatingNaming
{
    public string GetBeginner(string skillDiscipline) => $"Beginner {skillDiscipline}";
    public string GetAdvancedBeginner(string skillDiscipline) => $"Advanced Beginner {skillDiscipline}";
    public string GetExpert(string skillDiscipline) => $"Expert {skillDiscipline}";
    public string GetSepThoughtLeader(string skillDiscipline) => $"SEP Thought Leader {skillDiscipline}";
    public string GetIndustryThoughtLeader(string skillDiscipline) => $"Industry Thought Leader {skillDiscipline}";
}
