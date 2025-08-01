using terraservice.Communication.Client.Request;

namespace terraservice.Aplication.UseCase.Client.UpdateClient;

public interface IUpdateClientUseCase
{
    Task Execute(RequestUpdateClientJson request);
}