using terraservice.Communication.Point.Response;

namespace terraservice.Aplication.UseCase.Point.GetAll;

public interface IGetAllUseCase
{
    Task<ResponseAllPointsJson> Execute(int projectId);
}