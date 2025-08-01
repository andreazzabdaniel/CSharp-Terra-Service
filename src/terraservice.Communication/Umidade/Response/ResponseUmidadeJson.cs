namespace terraservice.Communication.Umidade.Response;

public class ResponseUmidadeJson
{
    public string Name { get; set; } = string.Empty;
    public List<float> Result { get; set; } = new();
    public float ResultMedia { get; set; }
    public List<int> Capsula { get; set; } = new();
    public List<float> Tara { get; set; } = new();
    public List<float> SoloMaisCapsula { get; set; } = new();
    public List<float> SoloSecoMaisCapsula { get; set; } = new();
}