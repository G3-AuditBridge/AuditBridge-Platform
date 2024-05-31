using AuditBridgePlatform.Profiles.Domain.Model.Aggregates;
using AuditBridgePlatform.Profiles.Domain.Model.ValueObjects;
using AuditBridgePlatform.Shared.Domain.Repositories;

namespace AuditBridgePlatform.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}