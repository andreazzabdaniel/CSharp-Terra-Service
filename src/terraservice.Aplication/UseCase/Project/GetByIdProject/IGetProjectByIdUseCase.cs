using terraservice.Communication.Project.Response;

namespace terraservice.Aplication.UseCase.Project.GetByIdProject;

public interface IGetProjectByIdUseCase
{
    Task<ResponseGetProjectJson> Execute(int projectId);
}