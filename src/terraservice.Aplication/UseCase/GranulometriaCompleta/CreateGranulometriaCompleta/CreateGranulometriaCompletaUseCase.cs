using AutoMapper;
using terraservice.Communication.UmidadeCompleta.Request;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.GranulometriaCompleta;
using terraservice.Domain.Repositories.Points;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.GranulometriaCompleta.CreateGranulometriaCompleta;

public class CreateGranulometriaCompletaUseCase : ICreateGranulometriaCompletaUseCase
{
    private readonly IPointReadOnlyRepository _readPointRepo;
    private readonly IGranulometriaCompletaReadOnlyRepository _readGranRepo;
    private readonly IGranulometriaCompletaWriteOnlyRepository _writeGranRepo;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public CreateGranulometriaCompletaUseCase(
        IPointReadOnlyRepository readPointRepo,
        IGranulometriaCompletaReadOnlyRepository readGranRepo,
        IGranulometriaCompletaWriteOnlyRepository writeGranRepo,
        IUnityOfWork unityOfWork,
        IMapper mapper)
    {
        _readPointRepo = readPointRepo;
        _readGranRepo = readGranRepo;
        _writeGranRepo = writeGranRepo;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }
    public async Task Execute(RequestCreateGranulometriaCompletaJson request)
    {
        var pointExist = await _readPointRepo.IsPointExist(request.PointId);
        if (pointExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var nameExist = await _readGranRepo.IsNameAlredyExist(request.Name);
        if (nameExist)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.NAME_EXIST);
        }

        var granulometriaCompleta = _mapper.Map<Domain.Entities.Ensaios.GranulometriaCompleta>(request);

        await _writeGranRepo.CreateGranulometriaCompleta(granulometriaCompleta);
        await _unityOfWork.Commit();
    }
}