namespace terraservice.Communication.Umidade.Request;

public class RequestCalculateUmidadeJson
{
    public string Name { get; set; } = string.Empty;
    public int UmidadeId { get; set; }
    
    public List<int> Capsula { get; set; } = new();
    public List<float> Tara { get; set; } = new();
    public List<float> SoloMaisCapsula { get; set; } = new();
    public List<float> SoloSecoMaisCapsula { get; set; } = new();
}