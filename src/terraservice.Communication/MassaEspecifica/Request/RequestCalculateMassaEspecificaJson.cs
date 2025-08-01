namespace terraservice.Communication.MassaEspecifica.Request;

public class RequestCalculateMassaEspecificaJson
{
    public int MassaEspecificaId { get; set; }
    public float Umidade { get; set; }
    public List<float> Temperaturas { get; set; } = [];
    public List<int> MassaSolo { get; set; } = [];
    public List<float> Pesos { get; set; } = [];
}