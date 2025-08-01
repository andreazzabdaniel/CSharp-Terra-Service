using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities.Ensaios;
using terraservice.Domain.Repositories.MassaEspecifica;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class MassaEspecificaRepository : IMassaEspecificaReadOnlyRepository, IMassaEspecificaWriteOnlyRepository
{
    private readonly TerraserviceDbContext _dbContext;
    public MassaEspecificaRepository(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> IsNameAlredyExist(string name)
    {
        return await _dbContext.MassaEspecifica.AsNoTracking().AnyAsync(config => config.Name == name);
    }

    public async Task<MassaEspecifica> GetMassaEspecifica(int massaEspecificaId)
    {
        return await _dbContext.MassaEspecifica.FindAsync(massaEspecificaId);
    }

    public async Task<bool> IsIdExists(int massaEspecificaId)
    {
        return await _dbContext.MassaEspecifica.AsNoTracking().AnyAsync(config => config.Id == massaEspecificaId);
    }

    public async Task<List<string>> GetAllNamesByPointId(int pointId)
    {
        return await _dbContext.MassaEspecifica.AsNoTracking()
            .Where(config => config.PointId == pointId)
            .Select(m => m.Name)
            .ToListAsync();
    }

    public async Task Create(MassaEspecifica request)
    {
        await _dbContext.MassaEspecifica.AddAsync(request);
    }

    public void CreateCalculo(MassaEspecifica request)
    {
        _dbContext.MassaEspecifica.Update(request);
    }

    public async Task SoftDelite(int massaEspecificaId)
    {
        await _dbContext.MassaEspecifica.Where(config => config.Id == massaEspecificaId)
            .ExecuteUpdateAsync(set => set.SetProperty(config => config.IsDelited, true));
    }
}