using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Domain.Repositories.GranulometriaCompleta;
using terraservice.Domain.Repositories.MassaEspecifica;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Projects;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Domain.Repositories.Users;
using terraservice.Domain.Security.Criptography;
using terraservice.Domain.Security.Token;
using terraservice.Infrastructure.DataAccess;
using terraservice.Infrastructure.DataAccess.Repositories;
using terraservice.Infrastructure.Security.Token;

namespace terraservice.Infrastructure;

public static class DependencyInjectionExtencion
{
    public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepository(services);


        services.AddScoped<IEncriptPassword, Infrastructure.Security.Criptography.BCrypt>();
        services.AddScoped<IAccesTokenGenerator, JwtTokenGenerator>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");
        
        var version = new Version(8, 0, 41);
        var serverVersion = new MySqlServerVersion(version);
        
        services.AddDbContext<TerraserviceDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IUsersReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUsersWriteOnlyRepository, UsersRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UsersRepository>();
        
        services.AddScoped<IClientReadOnlyRepository, ClientRepository>();
        services.AddScoped<IClientWriteOnlyRepository, ClientRepository>();
        
        services.AddScoped<IProjectReadOnlyRepository, ProjectRepository>();
        services.AddScoped<IProjectWriteOnlyRepository, ProjectRepository>();
        
        services.AddScoped<IPointReadOnlyRepository, PointRepository>();
        services.AddScoped<IPointWriteOnlyRepository, PointRepository>();
        
        services.AddScoped<IUmidadeReadOnlyRepository, UmidadeRepository>();
        services.AddScoped<IUmidadeWriteOnlyRepository, UmidadeRepository>();
        
        services.AddScoped<IGranulometriaCompletaReadOnlyRepository, GranulometriaCompletaRepository>();
        services.AddScoped<IGranulometriaCompletaWriteOnlyRepository, GranulometriaCompletaRepository>();
        
        services.AddScoped<IMassaEspecificaReadOnlyRepository, MassaEspecificaRepository>();
        services.AddScoped<IMassaEspecificaWriteOnlyRepository, MassaEspecificaRepository>();
        
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }
    
    
}