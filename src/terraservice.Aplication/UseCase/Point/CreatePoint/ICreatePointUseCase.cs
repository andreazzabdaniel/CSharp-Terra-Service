using terraservice.Communication.Point.Request;
using terraservice.Communication.Point.Response;

namespace terraservice.Aplication.UseCase.Point.CreatePoint;

public interface ICreatePointUseCase
{
    Task<ResponsePointJson> Execute(RequestCreatePointJson request);
}