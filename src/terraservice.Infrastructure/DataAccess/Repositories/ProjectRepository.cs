using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories.Projects;

namespace terraservice.Infrastructure.DataAccess.Repositories;

public class ProjectRepository : IProjectReadOnlyRepository, IProjectWriteOnlyRepository
{
    private readonly TerraserviceDbContext _dbContext;
    public ProjectRepository(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SaveProject(Projects projeto)
    {
        await _dbContext.Projects.AddAsync(projeto);
    }

    public async Task DeliteProject(int projectId)
    {
        await _dbContext.Projects.Where(project => project.ProjectId == projectId)
            .ExecuteUpdateAsync(set => set.SetProperty(c => c.IsDelited, true));
    }

    public async Task UpdateName(string name, int projectId)
    {
        await _dbContext.Projects.Where(config => config.ProjectId == projectId)
            .ExecuteUpdateAsync(set => set.SetProperty(c => c.Name, name));
    }

    public async Task<bool> NameAlredyExist(string name, int projectId)
    { 
        return await _dbContext.Projects.Where(config => config.ProjectId == projectId)
            .AnyAsync(config => config.Name == name);
    }

    public async Task<bool> IsProjectExist(int projectId)
    {
        return await _dbContext.Projects.AsNoTracking().AnyAsync(config => config.ProjectId == projectId);
    }

    public async Task<List<string>> GetProjectByClientId(int clientId)
    { 
        return await _dbContext.Projects.AsNoTracking()
            .Where(project => project.ClientId == clientId)
            .Select(p => p.Name)
            .ToListAsync();
    }

    public async Task<Projects> GetProjectById(int projectId)
    {
        return await _dbContext.Projects.AsNoTracking()
            .FirstOrDefaultAsync(config => config.ProjectId == projectId);
    }
}