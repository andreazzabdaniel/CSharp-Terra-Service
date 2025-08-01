using terraservice.Domain.Security.Criptography;
using BC = BCrypt.Net.BCrypt;

namespace terraservice.Infrastructure.Security.Criptography;

public class BCrypt : IEncriptPassword
{
    public string Encript(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
    {
        return BC.Verify(password, passwordHash);
    }
}