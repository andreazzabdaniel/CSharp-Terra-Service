using FluentValidation;
using terraservice.Communication.Umidade.Request;
using terraservice.Exception;

namespace terraservice.Aplication.UseCase.Umidade.CalculateUmidade;

public class CalculateUmidadeValidator : AbstractValidator<RequestCalculateUmidadeJson>
{
    public CalculateUmidadeValidator()
    {
        const int NUMERO_MAXIMO_DE_AMOSTRAS_POR_ENSAIO = 3;
        
        RuleFor(umidade => umidade.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        RuleFor(umidade => umidade.Capsula)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .Must(capsula => capsula.Count <= NUMERO_MAXIMO_DE_AMOSTRAS_POR_ENSAIO)
            .WithMessage(ResourceErrorMessages.MORE_THEN_TREE_ELEMENTS);
        RuleFor(umidade => umidade.Tara)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .Must(umidade => umidade.Count <= NUMERO_MAXIMO_DE_AMOSTRAS_POR_ENSAIO)
            .WithMessage(ResourceErrorMessages.MORE_THEN_TREE_ELEMENTS);
        RuleFor(umidade => umidade.SoloSecoMaisCapsula)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .Must(seco => seco.Count <= NUMERO_MAXIMO_DE_AMOSTRAS_POR_ENSAIO)
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);
        RuleFor(umidade => umidade.SoloMaisCapsula)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS)
            .Must(umido => umido.Count <= NUMERO_MAXIMO_DE_AMOSTRAS_POR_ENSAIO)
            .WithMessage(ResourceErrorMessages.MISSING_FIELDS);
        
    }
}