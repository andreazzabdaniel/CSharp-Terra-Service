using AutoMapper;
using terraservice.Communication.Project.Request;
using terraservice.Communication.Project.Response;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Project.CreateProject;

public class CreateProjectUseCase : ICreateProjectUseCase
{
    private readonly IMapper _mapper;
    private readonly IClientReadOnlyRepository _readClientRepo;
    private readonly IProjectWriteOnlyRepository _writeProjectRepo;
    private readonly IProjectReadOnlyRepository _readProjectRepo;
    private readonly IUnityOfWork _unityOfWork;
    public CreateProjectUseCase(
        IClientReadOnlyRepository readClientRepo,
        IMapper mapper,
        IProjectWriteOnlyRepository writeProjectRepo,
        IProjectReadOnlyRepository readProjectRepo,
        IUnityOfWork unityOfWork
    )
    {
        _readClientRepo = readClientRepo;
        _mapper = mapper;
        _writeProjectRepo = writeProjectRepo;
        _readProjectRepo = readProjectRepo;
        _unityOfWork = unityOfWork;
    }
    public async Task<ResponseProjectJson> Execute(RequestCreateProjectJson request)
    {
        var client = await _readClientRepo.FindClientById(request.ClientId);
        if (client is null)
        {
            throw new NotFountException(ResourceErrorMessages.CLIENT_DOESENT_EXIST);
        }
        

        var isNameAlredyExists = await _readProjectRepo.NameAlredyExist(request.Name, request.ClientId);
        if (isNameAlredyExists)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.REGISTER_ALREDY_EXISTS);
        }

        var project = _mapper.Map<Projects>(request);
        project.CreationDate = DateTime.Now;
        project.ModifiedDate = DateTime.Now;

        await _writeProjectRepo.SaveProject(project);
        await _unityOfWork.Commit();

        return new ResponseProjectJson()
        {
            Name = project.Name
        };
    }
}