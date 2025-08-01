using terraservice.Communication.Client.Response;
using terraservice.Domain.Entities;

namespace terraservice.Aplication.UseCase.Client.GetClient;

public interface IGetClientByIdUseCase
{
    Task<ResponseGetClientByIdJson> Execute(int clientId);
}