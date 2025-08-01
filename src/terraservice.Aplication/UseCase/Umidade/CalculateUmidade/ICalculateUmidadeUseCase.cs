using terraservice.Communication.Umidade.Request;
using terraservice.Communication.Umidade.Response;

namespace terraservice.Aplication.UseCase.Umidade.CalculateUmidade;

public interface ICalculateUmidadeUseCase
{
    Task<ResponseCalculateUmidadeJson> Execute(RequestCalculateUmidadeJson request);
}