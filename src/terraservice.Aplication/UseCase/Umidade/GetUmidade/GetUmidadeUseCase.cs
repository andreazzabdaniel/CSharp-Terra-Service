using AutoMapper;
using terraservice.Aplication.UseCase.Umidade.GetAllUmidade;
using terraservice.Communication.Umidade.Response;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Umidade.GetUmidade;

public class GetUmidadeUseCase : IGetUmidadeUseCase
{
    private readonly IMapper _mapper;
    private readonly IUmidadeReadOnlyRepository _readUmidadeRepo;
    public GetUmidadeUseCase(
        IMapper mapper,
        IUmidadeReadOnlyRepository readUmidadeRepo)
    {
        _mapper = mapper;
        _readUmidadeRepo = readUmidadeRepo;
    }
    
    public async Task<ResponseUmidadeJson> Execute(int umidadeId)
    {
        var umidadeExist = await _readUmidadeRepo.IsUmidadeExist(umidadeId);
        if (umidadeExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var umidade = await _readUmidadeRepo.GetUmidade(umidadeId);

        return _mapper.Map<ResponseUmidadeJson>(umidade);
    }
}