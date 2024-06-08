using AuditBridgePlatform.IAM.Domain.Model.Aggregates;
using AuditBridgePlatform.Shared.Domain.Repositories;

namespace AuditBridgePlatform.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);   
    
    bool ExistsByUsername(string username);
}