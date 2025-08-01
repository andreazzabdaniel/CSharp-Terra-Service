using terraservice.Domain.Repositories;

namespace terraservice.Infrastructure.DataAccess;

public class UnityOfWork : IUnityOfWork
{
    private readonly TerraserviceDbContext _dbContext;
    public UnityOfWork(TerraserviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}