using SkillJourney.Api.Shared.Contract.Users;

namespace SkillJourney.Api.Client.ApiClients;
public interface IUsersClient
{
    Task<IReadOnlyList<UserContract>> GetAllUsers();
    Task<UserContract> GetDevUser();
    Task<UserContract> GetUserById(Guid id);
}

internal class UsersClient : ApiClient, IUsersClient
{
    public UsersClient(IServerConfiguration serverConfig, HttpClient httpClient) : base(serverConfig, httpClient) { }

    public async Task<IReadOnlyList<UserContract>> GetAllUsers() =>
        await GetAsync<IReadOnlyList<UserContract>>("users");

    public async Task<UserContract> GetUserById(Guid id) =>
        await GetByIdAsync<UserContract>("users", id);

    public async Task<UserContract> GetDevUser() =>
        await GetAsync<UserContract>("devuser");
}
