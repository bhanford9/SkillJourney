using Microsoft.Extensions.DependencyInjection;
using SkillJourney.Database.BusinessAreas;
using SkillJourney.Database.NotableHighlights;
using SkillJourney.Database.OccupationalTitles;
using SkillJourney.Database.Permissions;
using SkillJourney.Database.SkillCategories;
using SkillJourney.Database.SkillFields;
using SkillJourney.Database.SkillRatings;
using SkillJourney.Database.TitlePermissionPermissions;
using SkillJourney.Database.UserPermissionPermissions;
using SkillJourney.Database.Users;

namespace SkillJourney.Database;
public static class DatabaseContainer
{
    public static IServiceCollection InitializeDatabase(this IServiceCollection container) => container
        .InitializeSkillRatings()
        .InitializeBusinessAreas()
        .InitializeSkillFields()
        .InitializeSkillCategories()
        .InitializeNotableHighlights()
        .InitializeUsers()
        .InitializeOccupationalTitles()
        .InitializeUserPermissions()
        .InitializeTitlePermissions()
        .InitializePermissions();
}
