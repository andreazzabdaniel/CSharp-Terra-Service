using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Communication.MassaEspecifica.Response;

namespace terraservice.Aplication.UseCase.MassaEspecifica.CreateMassaEspecifica;

public interface ICreateMassaEspecificaUseCase
{
    Task<ResponseMassaEspJson> Execute(RequestCreateMassaEspecificaJson request);
}