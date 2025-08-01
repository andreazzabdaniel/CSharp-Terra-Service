using terraservice.Communication.Project.Response;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Project.GetByIdProject;

public class GetProjectByIdUseCase : IGetProjectByIdUseCase
{
    private readonly IProjectReadOnlyRepository _readProjectRepo;
    private readonly IPointReadOnlyRepository _readPointRepo;
    public GetProjectByIdUseCase(
        IProjectReadOnlyRepository readProjectRepo,
        IPointReadOnlyRepository readPointRepo)
    {
        _readProjectRepo = readProjectRepo;
        _readPointRepo = readPointRepo;
    }
    
    public async Task<ResponseGetProjectJson> Execute(int projectId)
    {
        var projectExist = await _readProjectRepo.IsProjectExist(projectId);
        if (projectExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var points = await _readPointRepo.GetAllPoints(projectId);
        
        return new ResponseGetProjectJson()
        {
            Points = points
        };
    }
}