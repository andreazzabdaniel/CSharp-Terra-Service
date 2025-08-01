using FluentValidation;
using terraservice.Communication.GranulometriaCompleta.Request;
using terraservice.Communication.UmidadeCompleta.Request;
using terraservice.Exception;

namespace terraservice.Aplication.UseCase.GranulometriaCompleta.CalculateGranulometriaCompleta;

public class CalculateGranulometriaCompletaValidator : AbstractValidator<RequestCalculateGranulometriaCompletaJson>
{
    public CalculateGranulometriaCompletaValidator()
    {
        RuleFor(gran => gran.Id)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);
        RuleFor(gran => gran.MassaEspecifica)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(massa => massa.Must(c => c.GetType() == typeof(float)));
        RuleFor(gran => gran.PenGrosso)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(pen => pen.Must(c => c.GetType() == typeof(float)));
        RuleFor(gran => gran.PenFino)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(pen => pen.Must(c => c.GetType() == typeof(float)));
        RuleFor(gran => gran.Leitura)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(leitura => leitura.Must(c => c.GetType() == typeof(float)));
        RuleFor(gran => gran.Temperatura)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .ForEach(temp => temp.Must(c => c.GetType() == typeof(float)));
    }
}