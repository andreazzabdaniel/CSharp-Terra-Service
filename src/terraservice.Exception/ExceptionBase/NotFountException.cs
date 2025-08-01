using System.Net;

namespace terraservice.Exception.ExceptionBase;

public class NotFountException : TerraServiceException
{
    public NotFountException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetMessages()
    {
        return new List<string>() { Message };
    }
}