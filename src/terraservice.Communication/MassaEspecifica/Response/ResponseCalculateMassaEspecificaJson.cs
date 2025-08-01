namespace terraservice.Communication.MassaEspecifica.Response;

public class ResponseCalculateMassaEspecificaJson
{
    public List<float> MassaEspecificaIndividual { get; set; } = [];
    public float MassaEspecificaMedia { get; set; }
}