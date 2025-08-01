namespace terraservice.Domain.Security.Criptography;

public interface IEncriptPassword
{
    string Encript(string password);
    bool Verify(string password, string passwordHash);
}