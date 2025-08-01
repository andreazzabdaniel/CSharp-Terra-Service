using terraservice.Communication.Project.Request;
using terraservice.Communication.Project.Response;

namespace terraservice.Aplication.UseCase.Project.UpdateProject;

public interface IUpdateProjectUseCase
{
    Task<ResponseUpdateProjectJson> Execute(RequestUpdateProjectJson request);
}