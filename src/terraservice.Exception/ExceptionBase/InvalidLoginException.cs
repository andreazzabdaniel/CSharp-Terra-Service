using System.Net;

namespace terraservice.Exception.ExceptionBase;

public class InvalidLoginException : TerraServiceException
{
    public InvalidLoginException() : base(ResourceErrorMessages.INVALID_LOGGIN)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;
    public override List<string> GetMessages()
    {
        return [Message];
    }
}