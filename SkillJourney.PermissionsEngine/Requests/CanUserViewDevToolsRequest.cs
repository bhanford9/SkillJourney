﻿namespace SkillJourney.PermissionsEngine.Requests;
public interface ICanUserViewDevToolsRequest : IPermissionRequest;
public class CanUserViewDevToolsRequest : PermissionRequest, ICanUserViewDevToolsRequest;