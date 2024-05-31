using AuditBridgePlatform.Profiles.Domain.Model.Aggregates;
using AuditBridgePlatform.Profiles.Interfaces.REST.Resources;

namespace AuditBridgePlatform.Profiles.Interfaces.REST.Transform;

public static class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(entity.Id, entity.FullName, entity.EmailAddress, entity.StreetAddress);
    }
}