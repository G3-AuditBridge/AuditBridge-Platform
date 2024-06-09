using AuditBridgePlatform.IAM.Domain.Model.Aggregates;

namespace AuditBridgePlatform.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}