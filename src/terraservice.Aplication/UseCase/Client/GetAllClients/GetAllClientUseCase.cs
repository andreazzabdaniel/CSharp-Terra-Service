using terraservice.Communication.Client.Response;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Client.GetAllClients;

public class GetAllClientUseCase : IGetAllClientUseCase
{
    private readonly IClientReadOnlyRepository _readRepo;
    private readonly IClientWriteOnlyRepository _writeRepo;
    private readonly IUnityOfWork _unityOfWork;
    public GetAllClientUseCase(
        IClientReadOnlyRepository readRepo,
        IClientWriteOnlyRepository writeRepo,
        IUnityOfWork unityOfWork)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _unityOfWork = unityOfWork;
    }

    public async Task<ResponseGetAllClientsJson> Execute()
    {
        var allClients = await _readRepo.GetAllClients();
        if (!allClients.Any())
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.EMPTY_LIST_CLIENTS);
        }

        var clientsNames = allClients.Select(config => config.Name).ToList();

        return new ResponseGetAllClientsJson
        {
            AllClients = clientsNames
        };
    }
}