using terraservice.Communication.Client.Response;
using terraservice.Domain.Entities;

namespace terraservice.Aplication.UseCase.Client.GetAllClients;

public interface IGetAllClientUseCase
{
    Task<ResponseGetAllClientsJson> Execute();
}