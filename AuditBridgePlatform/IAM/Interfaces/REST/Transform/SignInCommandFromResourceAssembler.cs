using AuditBridgePlatform.IAM.Domain.Model.Commands;
using AuditBridgePlatform.IAM.Interfaces.REST.Resources;

namespace AuditBridgePlatform.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}