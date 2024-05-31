using AuditBridgePlatform.Profiles.Domain.Model.ValueObjects;

namespace AuditBridgePlatform.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);