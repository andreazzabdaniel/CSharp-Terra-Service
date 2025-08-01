using terraservice.Communication.UmidadeCompleta.Request;

namespace terraservice.Aplication.UseCase.GranulometriaCompleta.CreateGranulometriaCompleta;

public interface ICreateGranulometriaCompletaUseCase
{
    Task Execute(RequestCreateGranulometriaCompletaJson request);
}