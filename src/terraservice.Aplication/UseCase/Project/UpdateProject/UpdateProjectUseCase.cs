using terraservice.Communication.Project.Request;
using terraservice.Communication.Project.Response;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Project.UpdateProject;

public class UpdateProjectUseCase : IUpdateProjectUseCase
{
    private readonly IProjectReadOnlyRepository _readProjectRepo;
    private readonly IProjectWriteOnlyRepository _writeProjectRepo;
    private readonly IUnityOfWork _unityOfWork;
    public UpdateProjectUseCase(
        IProjectReadOnlyRepository readProjectRepo,
        IProjectWriteOnlyRepository writeProjectRepo,
        IUnityOfWork unityOfWork)
    {
        _readProjectRepo = readProjectRepo;
        _writeProjectRepo = writeProjectRepo;
        _unityOfWork = unityOfWork;
    }
    
    public async Task<ResponseUpdateProjectJson> Execute(RequestUpdateProjectJson request)
    {
        var projectExist = await _readProjectRepo.IsProjectExist(request.Id);
        if (projectExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var nameAlredyExist = await _readProjectRepo.NameAlredyExist(request.Name, request.Id);
        if (nameAlredyExist)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.NAME_EXIST);
        }

        var project = await _readProjectRepo.GetProjectById(request.Id);
        await _writeProjectRepo.UpdateName(project.Name, request.Id);
        await _unityOfWork.Commit();
        
        return new ResponseUpdateProjectJson()
        {
            Name = request.Name
        };
    }
}