using terraservice.Communication.Project.Request;
using terraservice.Communication.Project.Response;

namespace terraservice.Aplication.UseCase.Project.CreateProject;

public interface ICreateProjectUseCase
{
    Task<ResponseProjectJson> Execute(RequestCreateProjectJson request);
}