using terraservice.Communication.Client.Response;
using terraservice.Communication.Project.Response;
using terraservice.Domain.Entities;

namespace terraservice.Aplication.UseCase.Project.GetAllProjects;

public interface IGetAllProjectsUseCase
{
    Task<ResponseAllProjectsJson> Execute(int clientId);
}