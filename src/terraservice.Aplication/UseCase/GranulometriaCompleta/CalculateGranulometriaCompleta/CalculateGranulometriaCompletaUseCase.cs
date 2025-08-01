using terraservice.Communication.GranulometriaCompleta.Request;
using terraservice.Communication.UmidadeCompleta.Request;
using terraservice.Domain.Repositories.Points;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.GranulometriaCompleta.CalculateGranulometriaCompleta;

public class CalculateGranulometriaCompletaUseCase : ICalculateGranulometriaCompletaUseCase
{
    private readonly IPointReadOnlyRepository _readPointRepo;
    public CalculateGranulometriaCompletaUseCase(IPointReadOnlyRepository readPointRepo)
    {
        _readPointRepo = readPointRepo;
    }
    
    public async Task Execute(RequestCalculateGranulometriaCompletaJson request)
    {
        Validator(request);
        Calculate(request);
        
    }

    private void Validator(RequestCalculateGranulometriaCompletaJson request)
    {
        var result = new CalculateGranulometriaCompletaValidator().Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    private void Calculate(RequestCalculateGranulometriaCompletaJson request)
    {
        
    }
}