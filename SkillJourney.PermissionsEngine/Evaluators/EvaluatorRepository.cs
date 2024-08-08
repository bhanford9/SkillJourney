using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine.Evaluators;

internal interface IEvaluatorRepository
{
    IPermissionEvaluator GetEvaluator(IPermissionRequest request);
}

internal class EvaluatorRepository : IEvaluatorRepository
{
    private IReadOnlyDictionary<IPermissionRequest, IPermissionEvaluator> repository;

    // all requests and evaluators registered in DI are automatically dependency injected into enumerables
    public EvaluatorRepository(IEnumerable<IPermissionRequest> requests, IEnumerable<IPermissionEvaluator> evaluators)
    {
        repository = requests.ToDictionary(x => x, x => evaluators.First(y => y.CanEvaluate(x)));
    }

    public IPermissionEvaluator GetEvaluator(IPermissionRequest request) => repository[request];
}
