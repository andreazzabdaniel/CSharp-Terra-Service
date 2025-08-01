using AutoMapper;
using terraservice.Communication.Umidade.Response;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Umidade.GetAllUmidade;

public class GetAllUmidadeUseCase : IGetAllUmidadeUseCase
{
    private readonly IMapper _mapper;
    private readonly IPointReadOnlyRepository _readPointRepo;
    private readonly IUmidadeReadOnlyRepository _readUmidadeRepo;
    public GetAllUmidadeUseCase(
        IMapper mapper,
        IPointReadOnlyRepository readPointRepo,
        IUmidadeReadOnlyRepository readUmidadeRepo)
    {
        _mapper = mapper;
        _readPointRepo = readPointRepo;
        _readUmidadeRepo = readUmidadeRepo;
    }
    
    public async Task<ResponseAllUmidadeJson> Execute(int pointId)
    {
        var pointExist = await _readPointRepo.IsPointExist(pointId);
        if (pointExist == false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var umidades = await _readUmidadeRepo.GetAllUmidade(pointId);
        
        return new ResponseAllUmidadeJson
        {
            AllUmidades = _mapper.Map<List<UmidadeDto>>(umidades)
        };
    }
}