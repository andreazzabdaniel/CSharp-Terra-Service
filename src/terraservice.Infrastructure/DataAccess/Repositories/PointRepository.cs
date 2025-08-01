using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities;
using terraservice.Domain.Entities.Ensaios;
using terraservice.Domain.Repositories.Points;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class PointRepository : IPointReadOnlyRepository, IPointWriteOnlyRepository
{
    private readonly TerraserviceDbContext _dbContext;
    public PointRepository(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> IsPointAlredyExists(string name)
    {
        return await _dbContext.Points.AsNoTracking().AnyAsync(config => config.Name == name);
    }

    public async Task<List<string>> GetAllPoints(int projectId)
    {
        return await _dbContext.Points.AsNoTracking()
            .Where(point => point.ProjectId == projectId)
            .Where(point => point.IsDelited == false)
            .Select(p => p.Name)
            .ToListAsync();
    }
    
    public async Task<bool> IsPointExist(int pointId)
    {
        return await _dbContext.Points.AsNoTracking().AnyAsync(config => config.PointId == pointId);
    }

    public async Task CreatePoint(Points point)
    {
        await _dbContext.Points.AddAsync(point);
    }

    public async Task SoftDelitePoint(int pointId)
    {
        await _dbContext.Points.Where(config => config.PointId == pointId)
            .ExecuteUpdateAsync(set => set.SetProperty(config => config.IsDelited, true));
    }
}