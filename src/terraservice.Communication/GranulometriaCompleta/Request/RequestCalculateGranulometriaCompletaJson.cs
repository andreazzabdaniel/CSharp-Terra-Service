namespace terraservice.Communication.GranulometriaCompleta.Request;

public class RequestCalculateGranulometriaCompletaJson
{
    public int Id { get; set; }

    public List<float> MassaEspecifica { get; set; } = new();
    public List<float> PenGrosso { get; set; } = new();
    public List<float> PenFino { get; set; } = new();
    public List<float> Leitura { get; set; } = new();
    public List<float> Temperatura { get; set; } = new();
}