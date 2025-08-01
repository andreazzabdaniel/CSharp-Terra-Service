using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using terraservice.Aplication.AutoMapper;
using terraservice.Aplication.UseCase.Client.CreateClient;
using terraservice.Aplication.UseCase.Client.DeliteClient;
using terraservice.Aplication.UseCase.Client.GetAllClients;
using terraservice.Aplication.UseCase.Client.GetClient;
using terraservice.Aplication.UseCase.Client.UpdateClient;
using terraservice.Aplication.UseCase.GranulometriaCompleta.CreateGranulometriaCompleta;
using terraservice.Aplication.UseCase.MassaEspecifica.CalculateMassaEspecifica;
using terraservice.Aplication.UseCase.MassaEspecifica.CreateMassaEspecifica;
using terraservice.Aplication.UseCase.MassaEspecifica.DeleteMassaEspecifica;
using terraservice.Aplication.UseCase.MassaEspecifica.GetMassaEspecifica;
using terraservice.Aplication.UseCase.Point.CreatePoint;
using terraservice.Aplication.UseCase.Point.DeletePoints;
using terraservice.Aplication.UseCase.Point.GetAll;
using terraservice.Aplication.UseCase.Project.CreateProject;
using terraservice.Aplication.UseCase.Project.DeliteProject;
using terraservice.Aplication.UseCase.Project.GetAllProjects;
using terraservice.Aplication.UseCase.Project.GetByIdProject;
using terraservice.Aplication.UseCase.Project.UpdateProject;
using terraservice.Aplication.UseCase.Umidade.CalculateUmidade;
using terraservice.Aplication.UseCase.Umidade.CreateUmidade;
using terraservice.Aplication.UseCase.Umidade.DeleteUmidade;
using terraservice.Aplication.UseCase.Umidade.GetAllUmidade;
using terraservice.Aplication.UseCase.Umidade.GetUmidade;
using terraservice.Aplication.UseCase.User.SingIn;
using terraservice.Aplication.UseCase.User.VerifyLogin;

namespace terraservice.Aplication;

public static class DependencyInjectionExtencion
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddAutoMapper(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
        services.AddScoped<ISingInUser, SingInUser>();
        
        services.AddScoped<ICreateClientUseCase, CreateClientUseCase>();
        services.AddScoped<IDeliteClientUseCase, DeliteClientUseCase>();
        services.AddScoped<IUpdateClientUseCase, UpdaceClientUseCase>();
        services.AddScoped<IGetAllClientUseCase, GetAllClientUseCase>();
        
        services.AddScoped<ICreateProjectUseCase, CreateProjectUseCase>();
        services.AddScoped<IGetAllProjectsUseCase, GetAllProjectsUseCase>();
        services.AddScoped<IDeliteProjectById, DeliteProjectById>();
        services.AddScoped<IGetClientByIdUseCase, GetClientByIdUseCase>();
        services.AddScoped<IGetProjectByIdUseCase, GetProjectByIdUseCase>();
        services.AddScoped<IUpdateProjectUseCase, UpdateProjectUseCase>();

        services.AddScoped<ICreatePointUseCase, CreatePointUseCase>();
        services.AddScoped<IDeletePointsUseCase, DeletePointsUseCase>();
        services.AddScoped<IGetAllUseCase, GetAllUseCase>();
        
        services.AddScoped<ICalculateUmidadeUseCase, CalculateUmidadeUseCase>();
        services.AddScoped<ICreateUmidadeUseCase, CreateUmidadeUseCase>();
        services.AddScoped<IGetAllUmidadeUseCase, GetAllUmidadeUseCase>();
        services.AddScoped<IGetUmidadeUseCase, GetUmidadeUseCase>();
        services.AddScoped<IDeleteUmidadeUseCase, DeleteUmidadeUseCase>();
        
        services.AddScoped<ICreateGranulometriaCompletaUseCase, CreateGranulometriaCompletaUseCase>();
        
        services.AddScoped<ICreateMassaEspecificaUseCase, CreateMassaEspecificaUseCase>();
        services.AddScoped<ICalculateMassaEspecificaUseCase, CalculateMassaEspecificaUseCase>();
        services.AddScoped<IDeleteMassaEspecificaUseCase, DeleteMassaEspecificaUseCase>();
        services.AddScoped<IGetMassaEspecificaUseCase, GetMassaEspecificaUseCase>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
}