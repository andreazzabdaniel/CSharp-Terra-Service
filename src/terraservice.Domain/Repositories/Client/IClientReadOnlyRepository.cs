using terraservice.Domain.Entities;

namespace terraservice.Domain.Repositories.Client;

public interface IClientReadOnlyRepository
{
    Task<bool> FindIfClientNameAlredyExists(string name);
    Task<Clients> FindClientById(int id);
    Task<bool> VerifyIfClientExist(int id);
    Task<List<Clients>> GetAllClients();
}