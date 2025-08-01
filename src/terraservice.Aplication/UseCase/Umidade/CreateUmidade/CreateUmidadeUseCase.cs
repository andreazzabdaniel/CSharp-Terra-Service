using terraservice.Communication.Umidade.Request;
using terraservice.Communication.Umidade.Response;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Umidade.CreateUmidade;

public class CreateUmidadeUseCase : ICreateUmidadeUseCase
{
    private readonly IPointReadOnlyRepository _readPointRepo;
    private readonly IUmidadeReadOnlyRepository _readUmidadeRepo;
    private readonly IUmidadeWriteOnlyRepository _writeUmidadeRepo;
    private readonly IUnityOfWork _unityOfWork;
    public CreateUmidadeUseCase(
        IPointReadOnlyRepository readPointRepo,
        IUmidadeReadOnlyRepository readUmidadeRepo,
        IUmidadeWriteOnlyRepository writeUmidadeRepo,
        IUnityOfWork unityOfWork)
    {
        _readPointRepo = readPointRepo;
        _readUmidadeRepo = readUmidadeRepo;
        _writeUmidadeRepo = writeUmidadeRepo;
        _unityOfWork = unityOfWork;
    }
    
    public async Task<ResponseCreateUmidadeJson> Execute(RequestCreateUmidadeJson request)
    {
        var pointExist = await _readPointRepo.IsPointExist(request.PointId);
        if (pointExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var nameExist = await _readUmidadeRepo.VerifyIfNameAlredyExist(request.Name);
        if (nameExist)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.NAME_EXIST);
        }

        var umidade = new Domain.Entities.Ensaios.Umidade
        {
            Name = request.Name,
            PointId = request.PointId
        };

        await _writeUmidadeRepo.CreateUmidade(umidade);
        await _unityOfWork.Commit();

        return new ResponseCreateUmidadeJson()
        {
            Name = umidade.Name
        };
    }
}