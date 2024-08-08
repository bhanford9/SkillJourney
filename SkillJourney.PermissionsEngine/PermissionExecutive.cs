using SkillJourney.PermissionsEngine.Evaluators;
using SkillJourney.PermissionsEngine.Requests;

namespace SkillJourney.PermissionsEngine;

public interface IPermissionExecutive
{
    Task<bool> HasPermission(IPermissionRequest request);
}

internal class PermissionExecutive : IPermissionExecutive
{
    private readonly IEvaluatorRepository evaluations;

    public PermissionExecutive(IEvaluatorRepository evaluations)
    {
        this.evaluations = evaluations;
    }

    // TODO --> add error handling and return a result type instead of just a bool
    public Task<bool> HasPermission(IPermissionRequest request) => evaluations.GetEvaluator(request).Evaluate(request);
}
