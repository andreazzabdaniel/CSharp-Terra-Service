using terraservice.Communication.Client.Request;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Client.UpdateClient;

public class UpdaceClientUseCase : IUpdateClientUseCase
{
    private readonly IClientReadOnlyRepository _readRepo;
    private readonly IClientWriteOnlyRepository _writeRepo;
    private readonly IUnityOfWork _unityOfWork;
    public UpdaceClientUseCase(
        IClientReadOnlyRepository readRepo,
        IClientWriteOnlyRepository writeRepo,
        IUnityOfWork unityOfWork)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _unityOfWork = unityOfWork;
    }
    
    public async Task Execute(RequestUpdateClientJson request)
    {
        var isNullOrWhiteSpace = string.IsNullOrWhiteSpace(request.Name);
        if (isNullOrWhiteSpace)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.CLIENT_NAME_NULL);
        }

        var isNameExist = await _readRepo.FindIfClientNameAlredyExists(request.Name);
        if (isNameExist)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.CLIENT_NAME_ALREDY_EXISTS);
        }
        
        var client = await _readRepo.FindClientById(request.Id);

        await _writeRepo.UpdateName(request.Name, client.ClientId);
        await _unityOfWork.Commit();
    }
}