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
    private readonly IUserController userController;
    private readonly INotableHighlightsApi notableHighlightsApi;

    public UsersApi(IUserController userController, INotableHighlightsApi notableHighlightsApi)
    {
        this.userController = userController;
        this.notableHighlightsApi = notableHighlightsApi;
    }

    public async Task<IReadOnlyList<UserContract>> GetAllUsers() => await Task.FromResult(userController.GetAllUsers());

    public Task<UserContract> GetUserById(Guid id) => Task.FromResult(userController.GetUserById(id));

    public Task<UserContract> GetDevUser() => Task.FromResult(userController.GetDevUser());
}