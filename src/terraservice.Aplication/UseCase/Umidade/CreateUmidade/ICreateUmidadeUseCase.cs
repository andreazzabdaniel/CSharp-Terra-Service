using terraservice.Communication.Umidade.Request;
using terraservice.Communication.Umidade.Response;

namespace terraservice.Aplication.UseCase.Umidade.CreateUmidade;

public interface ICreateUmidadeUseCase
{
    Task<ResponseCreateUmidadeJson> Execute(RequestCreateUmidadeJson request);
}