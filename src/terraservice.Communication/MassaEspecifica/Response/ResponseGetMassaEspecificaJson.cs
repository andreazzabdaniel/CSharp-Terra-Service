namespace terraservice.Communication.MassaEspecifica.Response;

public class ResponseGetMassaEspecificaJson
{
    public string Name { get; set; } = string.Empty;
    
    public List<float> Temperaturas { get; set; } = [];
    public List<int> MassaSolo { get; set; } = [];
    public List<float> Pesos { get; set; } = [];
    
    public List<float> MassaEspecificaIndividual { get; set; } = [];
    public float MassaEspecificaMedia { get; set; }
}