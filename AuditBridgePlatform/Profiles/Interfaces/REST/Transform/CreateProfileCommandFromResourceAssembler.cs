using AuditBridgePlatform.Profiles.Domain.Model.Commands;
using AuditBridgePlatform.Profiles.Interfaces.REST.Resources;

namespace AuditBridgePlatform.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email, resource.Street,
            resource.Number, resource.City, resource.PostalCode, resource.Country);
    }
}