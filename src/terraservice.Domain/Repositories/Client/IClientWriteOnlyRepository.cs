using terraservice.Domain.Entities;

namespace terraservice.Domain.Repositories.Client;

public interface IClientWriteOnlyRepository
{
    Task CreateClient(Clients client);
    Task UpdateSoftDelite(int id);
    Task UpdateName(string name, int id);
}