using AuditBridgePlatform.IAM.Domain.Model.Aggregates;
using AuditBridgePlatform.IAM.Interfaces.REST.Resources;

namespace AuditBridgePlatform.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}