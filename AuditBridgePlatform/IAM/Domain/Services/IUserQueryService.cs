using AuditBridgePlatform.IAM.Domain.Model.Aggregates;
using AuditBridgePlatform.IAM.Domain.Model.Queries;

namespace AuditBridgePlatform.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}