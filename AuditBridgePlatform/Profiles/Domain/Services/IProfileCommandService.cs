using AuditBridgePlatform.Profiles.Domain.Model.Aggregates;
using AuditBridgePlatform.Profiles.Domain.Model.Commands;

namespace AuditBridgePlatform.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}