using terraservice.Communication.Umidade.Response;

namespace terraservice.Aplication.UseCase.Umidade.GetUmidade;

public interface IGetUmidadeUseCase
{
    Task<ResponseUmidadeJson> Execute(int umidadeId);
}