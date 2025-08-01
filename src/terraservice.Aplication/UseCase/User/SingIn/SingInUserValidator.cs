using FluentValidation;
using terraservice.Communication.User;

namespace terraservice.Aplication.UseCase.User.SingIn;

public class SingInUserValidator : AbstractValidator<SingInRequestJson>
{
    public SingInUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Nome invalido");
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email Invalido")
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage("Email Invalido");
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<SingInRequestJson>());
    }
}