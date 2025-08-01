using terraservice.Communication.Point.Response;

namespace terraservice.Aplication.UseCase.Point.GetPoint;

public interface IGetMassaEspecificaUseCase
{
    Task<ResponseGetPointJson> Execute(int pointId);
}