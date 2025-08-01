using Microsoft.Extensions.DependencyInjection;
using terraservice.Infrastructure.DataAccess;

namespace terraservice.Infrastructure.Migrations;

public static class DataBaseMigration
{
    public static async Task MigrateDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<TerraserviceDbContext>();
    }
}