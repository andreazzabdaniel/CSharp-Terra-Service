using terraservice.Communication.Umidade.Response;

namespace terraservice.Aplication.UseCase.Umidade.GetAllUmidade;

public interface IGetAllUmidadeUseCase
{
    Task<ResponseAllUmidadeJson> Execute(int pointId);
}