using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace terraservice.Domain.Entities.Ensaios;

public class MassaEspecifica
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public bool IsDelited { get; set; } = false;
    
    public int PointId { get; set; }
    public Points Point { get; set; }

    public List<float> Temperaturas { get; set; } = [];
    public List<int> MassaSolo { get; set; } = [];
    public List<float> Pesos { get; set; } = [];

    public List<float> MassaEspecificaIndividual { get; set; } = [];
    public float MassaEspecificaMedia { get; set; }
}