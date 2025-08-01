using terraservice.Communication.Client.Request;
using terraservice.Communication.Client.Response;

namespace terraservice.Aplication.UseCase.Client.CreateClient;

public interface ICreateClientUseCase
{
    Task<ResponseClientJson> Execute(RequestCreateClientJson Name);
}