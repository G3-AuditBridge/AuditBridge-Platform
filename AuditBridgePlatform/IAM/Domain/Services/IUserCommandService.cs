using AuditBridgePlatform.IAM.Domain.Model.Aggregates;
using AuditBridgePlatform.IAM.Domain.Model.Commands;

namespace AuditBridgePlatform.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}