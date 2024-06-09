using AuditBridgePlatform.IAM.Domain.Model.Aggregates;
using AuditBridgePlatform.IAM.Domain.Repositories;
using AuditBridgePlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using AuditBridgePlatform.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuditBridgePlatform.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository 
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}