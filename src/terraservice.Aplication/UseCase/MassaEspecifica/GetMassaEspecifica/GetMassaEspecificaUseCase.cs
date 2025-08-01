using AutoMapper;
using terraservice.Communication.MassaEspecifica.Response;
using terraservice.Domain.Repositories.MassaEspecifica;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.MassaEspecifica.GetMassaEspecifica;

public class GetMassaEspecificaUseCase : IGetMassaEspecificaUseCase
{
    private readonly IMassaEspecificaReadOnlyRepository _readMassaEspRepo;
    private readonly IMapper _mapper;
    public GetMassaEspecificaUseCase(
        IMassaEspecificaReadOnlyRepository readMassaEspRepo,
        IMapper mapper)
    {
        _readMassaEspRepo = readMassaEspRepo;
        _mapper = mapper;
    }
    
    public async Task<ResponseGetMassaEspecificaJson> Execute(int massaEspecificaId)
    {
        var massaEspecificaExist = await _readMassaEspRepo.IsIdExists(massaEspecificaId);
        if (massaEspecificaExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var ensaio = await _readMassaEspRepo.GetMassaEspecifica(massaEspecificaId);
        var response = _mapper.Map<ResponseGetMassaEspecificaJson>(ensaio);

        return response;
    }
}