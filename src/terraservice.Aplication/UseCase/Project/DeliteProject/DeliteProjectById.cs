using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Project.DeliteProject;

public class DeliteProjectById : IDeliteProjectById
{
    private readonly IProjectReadOnlyRepository _readRepo; 
    private readonly IProjectWriteOnlyRepository _writeRepo;
    private readonly IUnityOfWork _unityOfWork;

    public DeliteProjectById(
        IProjectReadOnlyRepository readRepo,
        IProjectWriteOnlyRepository writeRepo,
        IUnityOfWork unityOfWork)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _unityOfWork = unityOfWork;
    }
    
    public async Task Execute(int projectId)
    {
        var isProjectExist = await _readRepo.IsProjectExist(projectId);
        if (isProjectExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        await _writeRepo.DeliteProject(projectId);
        await _unityOfWork.Commit();
    }
}