using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Communication.MassaEspecifica.Response;

namespace terraservice.Aplication.UseCase.MassaEspecifica.CalculateMassaEspecifica;

public interface ICalculateMassaEspecificaUseCase
{
   Task<ResponseCalculateMassaEspecificaJson> Execute(RequestCalculateMassaEspecificaJson request);
}