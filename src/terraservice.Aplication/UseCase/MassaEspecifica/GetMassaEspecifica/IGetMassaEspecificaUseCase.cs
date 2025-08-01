using terraservice.Communication.MassaEspecifica.Response;

namespace terraservice.Aplication.UseCase.MassaEspecifica.GetMassaEspecifica;

public interface IGetMassaEspecificaUseCase
{
    Task<ResponseGetMassaEspecificaJson> Execute(int massaEspecificaId);
}