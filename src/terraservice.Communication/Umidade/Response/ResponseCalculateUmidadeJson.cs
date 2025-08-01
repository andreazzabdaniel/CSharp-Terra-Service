namespace terraservice.Communication.Umidade.Response;

public class ResponseCalculateUmidadeJson
{
    public List<float> Resultados { get; set; } = [];
    public float Media { get; set; }
}