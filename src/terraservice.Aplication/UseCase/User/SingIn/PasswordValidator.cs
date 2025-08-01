using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Validators;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.User.SingIn;

public class PasswordValidator<T> : PropertyValidator<T, string>
{
    private string ERRORMESSAGE = "ErrorMessage";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERRORMESSAGE}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ERRORMESSAGE, ResourceErrorMessages.PASSWORD_ERROR);
            return false;
        }

        if (password.Length < 8)
        {
            context.MessageFormatter.AppendArgument(ERRORMESSAGE, ResourceErrorMessages.PASSWORD_ERROR);
            return false;
        }
        
        if (Regex.IsMatch(password, @"[A-Z]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERRORMESSAGE, ResourceErrorMessages.PASSWORD_ERROR);
            return false;
        }
        
        if (Regex.IsMatch(password, @"[a-z]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERRORMESSAGE, ResourceErrorMessages.PASSWORD_ERROR);
            return false;
        }
        
        if (Regex.IsMatch(password, @"[0-9]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERRORMESSAGE, ResourceErrorMessages.PASSWORD_ERROR);
            return false;
        }
        
        if (Regex.IsMatch(password, @"[\!\?\*\.]+") == false)
        {
            context.MessageFormatter.AppendArgument(ERRORMESSAGE, ResourceErrorMessages.PASSWORD_ERROR);
            return false;
        }
        
        return true;
    }

    public override string Name => "PasswordValidator";

}