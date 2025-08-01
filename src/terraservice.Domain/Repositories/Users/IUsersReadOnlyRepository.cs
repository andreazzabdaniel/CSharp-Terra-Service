using terraservice.Domain.Entities;

namespace terraservice.Domain.Repositories.Users;

public interface IUsersReadOnlyRepository
{
    Task<User> GetUserByEmail(string email);
    Task<bool> VerifyIfEmailExists(string email);
}