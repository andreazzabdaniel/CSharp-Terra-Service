using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace terraservice.Domain.Entities.Ensaios;

public class GranulometriaCompleta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public bool IsDelited { get; set; } = false;
    
    public int PointId { get; set; }
    public Points Point { get; set; }

    public List<float> PenGrosso { get; set; } = new();
    public List<float> PenFino { get; set; } = new();
    public List<float> Leitura { get; set; } = new();
    public List<float> Temperatura { get; set; } = new();
}