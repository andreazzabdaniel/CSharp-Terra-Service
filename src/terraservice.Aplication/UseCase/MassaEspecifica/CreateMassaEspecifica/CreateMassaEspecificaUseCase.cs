using AutoMapper;
using terraservice.Aplication.UseCase._00___Geral;
using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Communication.MassaEspecifica.Response;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.MassaEspecifica;
using terraservice.Domain.Repositories.Points;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.MassaEspecifica.CreateMassaEspecifica;



public class CreateMassaEspecificaUseCase : ICreateMassaEspecificaUseCase
{
    private readonly IMapper _mapper;
    private readonly IPointReadOnlyRepository _readPointRepo;
    private readonly IMassaEspecificaReadOnlyRepository _readMassaRepo;
    private readonly IMassaEspecificaWriteOnlyRepository _writeMassaRepo;
    private readonly IUnityOfWork _unityOfWork;
    public CreateMassaEspecificaUseCase(
        IMapper mapper,
        IPointReadOnlyRepository readPointRepo,
        IMassaEspecificaReadOnlyRepository readMassaRepo,
        IMassaEspecificaWriteOnlyRepository writeMassaRepo,
        IUnityOfWork unityOfWork)
    {
        _mapper = mapper;
        _readPointRepo = readPointRepo;
        _readMassaRepo = readMassaRepo;
        _writeMassaRepo = writeMassaRepo;
        _unityOfWork = unityOfWork;
    }
    
    public async Task<ResponseMassaEspJson> Execute(RequestCreateMassaEspecificaJson request)
    {
        var pointExit = await _readPointRepo.IsPointExist(request.PointId);
        if (!pointExit)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var nameAlredyExist = await _readMassaRepo.IsNameAlredyExist(request.Name);
        if (nameAlredyExist)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.NAME_EXIST);
        }

        var massaEspecifica = _mapper.Map<Domain.Entities.Ensaios.MassaEspecifica>(request);
        await _writeMassaRepo.Create(massaEspecifica);
        await _unityOfWork.Commit();

        return new ResponseMassaEspJson()
        {
            Name = massaEspecifica.Name
        };
    }
}