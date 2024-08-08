using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Server.Controllers;
using SkillJourney.Api.Shared.Contract.Users;

namespace SkillJourney.Api.Server.Apis;

public interface IUsersApi
{
    Task<IReadOnlyList<UserContract>> GetAllUsers();
    Task<UserContract> GetDevUser();
    Task<UserContract> GetUserById(Guid id);
}

public class UsersApi : IUsersApi
{
    private readonly IControllerProvider controllers;
    private readonly IContractBuilderProvider contractBuilders;
    private readonly INotableHighlightsApi notableHighlightsApi;

    public UsersApi(
        IControllerProvider controllerProvider,
        IContractBuilderProvider contractBuilderProvider,
        INotableHighlightsApi notableHighlightsApi)
    {
        this.controllers = controllerProvider;
        this.contractBuilders = contractBuilderProvider;
        this.notableHighlightsApi = notableHighlightsApi;
    }

    public async Task<IReadOnlyList<UserContract>> GetAllUsers()
        => await Task.WhenAll(controllers.User
            .GetAllUsers()
            .Select(BuildFullContract));

    public Task<UserContract> GetUserById(Guid id)
        => BuildFullContract(controllers.User.GetUserById(id));

    public Task<UserContract> GetDevUser()
        => BuildFullContract(controllers.User.GetDevUser());

    private async Task<UserContract> BuildFullContract(UserSubContract user)
        => contractBuilders.User.BuildContract(
            user,
            controllers.OccupationalTitle.FromId(user.TitleId),
            await notableHighlightsApi.GetHighlightsForUser(user.Id),
            controllers.Permission.GetPermissions(user.Id, user.TitleId));
}