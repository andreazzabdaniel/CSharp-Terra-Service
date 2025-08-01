using terraservice.Domain.Entities;

namespace terraservice.Domain.Security.Token;

public interface IAccesTokenGenerator
{
    string Generate(User user);
}