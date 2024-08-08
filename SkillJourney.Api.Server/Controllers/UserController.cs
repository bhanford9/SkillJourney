using SkillJourney.Api.Server.ContractBuilders;
using SkillJourney.Api.Shared.Contract.Users;
using SkillJourney.Database.Users;

namespace SkillJourney.Api.Server.Controllers;

public interface IUserController
{
    IReadOnlyList<UserSubContract> GetAllUsers();
    UserSubContract GetDevUser();
    UserSubContract GetUserById(Guid id);
}

public class UserController : IUserController
{
    private readonly IUsersDatabaseApi usersDatabaseApi;
    private readonly IUserContractBuilder userContractBuilder;

    public UserController(
        IUsersDatabaseApi usersDatabaseApi,
        IUserContractBuilder userContractBuilder)
    {
        this.usersDatabaseApi = usersDatabaseApi;
        this.userContractBuilder = userContractBuilder;
    }

    public IReadOnlyList<UserSubContract> GetAllUsers()
        => usersDatabaseApi.GetAllUsers().Select(userContractBuilder.BuildSubContract).ToList();

    public UserSubContract GetUserById(Guid id) => userContractBuilder.BuildSubContract(usersDatabaseApi.GetUserById(id));

    public UserSubContract GetDevUser() => userContractBuilder.BuildSubContract(usersDatabaseApi.GetDevUser());
}