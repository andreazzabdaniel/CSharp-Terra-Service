using terraservice.Domain.Entities;

namespace terraservice.Domain.Repositories.Users;

public interface IUsersWriteOnlyRepository
{
    Task RegisterUser(User user);
}