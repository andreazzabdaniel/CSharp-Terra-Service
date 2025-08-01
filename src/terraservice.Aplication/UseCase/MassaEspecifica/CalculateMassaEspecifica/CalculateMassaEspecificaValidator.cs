using FluentValidation;
using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Exception;

namespace terraservice.Aplication.UseCase.MassaEspecifica.CalculateMassaEspecifica;

public class CalculateMassaEspecificaValidator : AbstractValidator<RequestCalculateMassaEspecificaJson>
{
    public CalculateMassaEspecificaValidator()
    {
        RuleFor(ensaio => ensaio.Pesos)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(peso => peso.Must(p => p.GetType() == typeof(int)))
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);
        
        RuleFor(ensaio => ensaio.Temperaturas)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(temp => temp.Must(p => p.GetType() == typeof(float)))
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);
        
        RuleFor(ensaio => ensaio.MassaSolo)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(massa => massa.Must(p => p.GetType() == typeof(float)))
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);

        RuleFor(ensaio => ensaio.Umidade)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);
    }
}