using System.Net;

namespace terraservice.Exception.ExceptionBase;

public class ErrorOnValidationException : TerraServiceException
{
    private readonly List<String> _errorMessages;
    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errorMessages = errorMessages;
    }
    public ErrorOnValidationException(string errorMessages) : base(string.Empty)
    {
        _errorMessages = [errorMessages];
    }


    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetMessages()
    {
        return _errorMessages;
    }
}