using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories.Client;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class ClientRepository : IClientReadOnlyRepository, IClientWriteOnlyRepository
{
    private readonly TerraserviceDbContext _dbcontext;
    public ClientRepository(TerraserviceDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    
    public async Task<bool> FindIfClientNameAlredyExists(string name)
    {
        return await _dbcontext.Clients.AsNoTracking().AnyAsync(client => client.Name.Equals(name));
    }

    public async Task<Clients> FindClientById(int id)
    {
        return await _dbcontext.Clients.AsNoTracking().FirstOrDefaultAsync(client => client.ClientId.Equals(id));
    }

    public async Task<bool> VerifyIfClientExist(int id)
    {
        return await _dbcontext.Clients.AsNoTracking().AnyAsync(config => config.ClientId == id);
    }

    public async Task<List<Clients>> GetAllClients()
    {
        return await _dbcontext.Clients.Where(config => config.IsDelited.Equals(false)).ToListAsync();
    }

    public async Task CreateClient(Clients client)
    {
        await _dbcontext.Clients.AddAsync(client);
    }

    public async Task UpdateSoftDelite(int id)
    {
        await _dbcontext.Clients.Where(client => client.ClientId == id)
            .ExecuteUpdateAsync(set => set.SetProperty(c => c.IsDelited, true));
    }

    public async Task UpdateName(string name, int id)
    {
        await _dbcontext.Clients.Where(client => client.ClientId == id)
            .ExecuteUpdateAsync(set => set.SetProperty(c => c.Name, name));
    }
}