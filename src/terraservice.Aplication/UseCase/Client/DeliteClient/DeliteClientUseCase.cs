using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Client.DeliteClient;

public class DeliteClientUseCase : IDeliteClientUseCase
{
    private readonly IClientReadOnlyRepository _readRepo;
    private readonly IClientWriteOnlyRepository _writeRepo;
    private readonly IUnityOfWork _unityOfWork;
    public DeliteClientUseCase(
        IClientReadOnlyRepository readRepo,
        IClientWriteOnlyRepository writeRepo,
        IUnityOfWork unityOfWork
        )
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _unityOfWork = unityOfWork;
    }
    public async Task Execute(int id)
    {
        var client = await _readRepo.FindClientById(id);
        if (client is null)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.CLIENT_DOESENT_EXIST);
        }

        await _writeRepo.UpdateSoftDelite(id);
        await _unityOfWork.Commit();
    }
}