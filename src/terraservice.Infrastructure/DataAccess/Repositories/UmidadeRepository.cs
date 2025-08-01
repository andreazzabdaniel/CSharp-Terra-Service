using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities.Ensaios;
using terraservice.Domain.Repositories.Umidade;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class UmidadeRepository : IUmidadeReadOnlyRepository, IUmidadeWriteOnlyRepository
{
    private readonly TerraserviceDbContext _dbContext;
    public UmidadeRepository(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> VerifyIfNameAlredyExist(string name)
    {
        return await _dbContext.Umidade.AsNoTracking().AnyAsync(umidade => umidade.Name == name);
    }
    
    public async Task<bool> IsUmidadeExist (int umidadeId)
    {
        return await _dbContext.Umidade.AsNoTracking().AnyAsync(config => config.PointId == umidadeId);
    }

    public async Task<bool> IsNameAlredyExist(string name)
    {
        return await _dbContext.Umidade.AsNoTracking().AnyAsync(umidade => umidade.Name == name);
    }

    public async Task<List<Umidade>> GetAllUmidade(int pointId)
    {
        return await _dbContext.Umidade.AsNoTracking()
            .Where(config => config.PointId == pointId)
            .Where(config => config.IsDelited == false)
            .ToListAsync();
    }

    public async Task<List<string>> GetAllNamesByPointId(int pointId)
    {
        return await _dbContext.Umidade.AsNoTracking()
            .Where(config => config.PointId == pointId)
            .Select(p => p.Name)
            .ToListAsync();
    }

    public async Task<Umidade> GetUmidade(int umidadeId)
    {
        return await _dbContext.Umidade.FindAsync(umidadeId);
    }
    
    public async Task CreateCalculateUmidade(Umidade umidade)
    {
        await _dbContext.Umidade.AddAsync(umidade);
    }

    public async Task CreateUmidade(Umidade umidade)
    {
        await _dbContext.Umidade.AddAsync(umidade);
    }

    public async Task DeleteUmidade(int umidadeId)
    {
        await _dbContext.Umidade.Where(config => config.Id == umidadeId)
            .ExecuteUpdateAsync(set => set.SetProperty(u => u.IsDelited, true));
    }
}