namespace SkillJourney.PermissionsEngine.Requests;
public interface ICanUserViewProfilesRequest : IPermissionRequest;

public class CanUserViewProfilesRequest : PermissionRequest, ICanUserViewProfilesRequest;
