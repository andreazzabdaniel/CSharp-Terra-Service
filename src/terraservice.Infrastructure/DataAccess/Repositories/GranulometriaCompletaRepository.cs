using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities.Ensaios;
using terraservice.Domain.Repositories.GranulometriaCompleta;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class GranulometriaCompletaRepository : IGranulometriaCompletaReadOnlyRepository, IGranulometriaCompletaWriteOnlyRepository
{
    private readonly TerraserviceDbContext _dbContext;
    public GranulometriaCompletaRepository(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> IsNameAlredyExist(string name)
    {
        return await _dbContext.GranulometriaCompleta.AnyAsync(config => config.Name == name);
    }

    public async Task CreateGranulometriaCompleta(GranulometriaCompleta request)
    {
        await _dbContext.GranulometriaCompleta.AddAsync(request);
    }
}