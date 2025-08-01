
using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories.Users;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class UsersRepository : IUsersWriteOnlyRepository, IUsersReadOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly TerraserviceDbContext _dbContext;
    public UsersRepository(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(config => config.Email == email);
    }

    public async Task<bool> VerifyIfEmailExists(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task RegisterUser(User user)
    {
        await _dbContext.AddAsync(user);
    }
}