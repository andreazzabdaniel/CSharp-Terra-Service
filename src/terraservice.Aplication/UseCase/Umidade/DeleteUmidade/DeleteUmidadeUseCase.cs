using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Umidade.DeleteUmidade;

public class DeleteUmidadeUseCase : IDeleteUmidadeUseCase
{
    private readonly IUmidadeReadOnlyRepository _readUmidadeRepo;
    private readonly IUmidadeWriteOnlyRepository _writeUmidadeRepo;
    private readonly IUnityOfWork _unityOfWork;
    public DeleteUmidadeUseCase(
        IUmidadeReadOnlyRepository readUmidadeRepo,
        IUmidadeWriteOnlyRepository writeUmidadeRepo,
        IUnityOfWork unityOfWork)
    {
        _readUmidadeRepo = readUmidadeRepo;
        _writeUmidadeRepo = writeUmidadeRepo;
        _unityOfWork = unityOfWork;
    }
    
    public async Task Execute(int umidadeId)
    {
        var umidadeExist = await _readUmidadeRepo.IsUmidadeExist(umidadeId);
        if (umidadeExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        await _writeUmidadeRepo.DeleteUmidade(umidadeId);
        await _unityOfWork.Commit();
    }
}