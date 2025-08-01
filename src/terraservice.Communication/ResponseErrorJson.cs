namespace terraservice.Communication;

public class ResponseErrorJson
{
    
    public ResponseErrorJson(string message)
    {
        ErrorMessage = [message];
    }

    public ResponseErrorJson(List<string> message)
    {
        ErrorMessage = message;
    }
    
    public List<string> ErrorMessage { get; set; }
}