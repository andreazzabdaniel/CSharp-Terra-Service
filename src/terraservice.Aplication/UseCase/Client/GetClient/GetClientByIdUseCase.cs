using terraservice.Communication.Client.Response;
using terraservice.Domain.Repositories.Client;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Client.GetClient;

public class GetClientByIdUseCase : IGetClientByIdUseCase
{
    private readonly IClientReadOnlyRepository _readClientRepo;
    private readonly IProjectReadOnlyRepository _readProjectRepo;
    public GetClientByIdUseCase(
        IClientReadOnlyRepository readClientRepo,
        IProjectReadOnlyRepository readProjectRepo
        )
    {
        _readClientRepo = readClientRepo;
        _readProjectRepo = readProjectRepo;
    }
    public async Task<ResponseGetClientByIdJson> Execute(int clientId)
    {
        var clientExist = await _readClientRepo.VerifyIfClientExist(clientId);
        if (clientExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var projects = await _readProjectRepo.GetProjectByClientId(clientId);
        
        return new ResponseGetClientByIdJson()
        {
            Projects = projects
        };
    }
}