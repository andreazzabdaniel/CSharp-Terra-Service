using terraservice.Communication.MassaEspecifica.Response;
using terraservice.Communication.Point.Response;
using terraservice.Domain.Repositories.MassaEspecifica;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Point.GetPoint;

public class GetMassaEspecificaUseCase : IGetMassaEspecificaUseCase
{
    private readonly IUmidadeReadOnlyRepository _readUmidadeRepo;
    private readonly IMassaEspecificaReadOnlyRepository _readMassaEspRepo;
    public GetMassaEspecificaUseCase(
        IUmidadeReadOnlyRepository readUmidadeRepo,
        IMassaEspecificaReadOnlyRepository readMassaEspRepo)
    {
        _readUmidadeRepo = readUmidadeRepo;
        _readMassaEspRepo = readMassaEspRepo;
    }
    public async Task<ResponseGetPointJson> Execute(int pointId)
    {
        var umidades = await _readUmidadeRepo.GetAllNamesByPointId(pointId);
        if (umidades.Count == 0)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var massaEspecifica = await _readMassaEspRepo.GetAllNamesByPointId(pointId);
        if (massaEspecifica.Count == 0)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }
        
        return new ResponseGetPointJson()
        {
            Umidades = umidades,
            MassaEspecifica = massaEspecifica
        };
    }
}