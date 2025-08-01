

using System.Text.Json;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase._00___Geral;

public class MassaEspecificaAguaPelaTemperatura
{
    private readonly Dictionary<float, float> _densidades;
    public MassaEspecificaAguaPelaTemperatura()
    {
        string filePath = "DensidadeTemperaturaAgua.json";

        if (!File.Exists(filePath))
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        string json = File.ReadAllText(filePath);
        _densidades = JsonSerializer.Deserialize<Dictionary<float, float>>(json)
            ?? new Dictionary<float, float>();
    }
    public List<float> CalculateDensidadeAgua(List<float> temperaturas)
    {
        List<float> densidades = new List<float>();
        
        foreach (float chave in temperaturas)
        {
            if (_densidades.TryGetValue(chave, out float valor))
            {
                densidades.Add(valor);
            }
            else
            {
                densidades.Add(float.NaN);
            }
        }

        return densidades;
    }
}