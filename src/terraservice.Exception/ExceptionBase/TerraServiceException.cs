namespace terraservice.Exception.ExceptionBase;

public abstract class TerraServiceException : SystemException
{
    public TerraServiceException(string message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetMessages();
}