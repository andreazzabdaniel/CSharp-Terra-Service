using terraservice.Communication.GranulometriaCompleta.Request;
using terraservice.Communication.UmidadeCompleta.Request;

namespace terraservice.Aplication.UseCase.GranulometriaCompleta.CalculateGranulometriaCompleta;

public interface ICalculateGranulometriaCompletaUseCase
{
    Task Execute(RequestCalculateGranulometriaCompletaJson request);
}