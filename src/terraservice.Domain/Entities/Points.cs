using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using terraservice.Domain.Entities.Ensaios;

namespace terraservice.Domain.Entities;

public class Points
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int PointId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsDelited { get; set; } = false;

    
    public int ProjectId { get; set; }
    public Projects Project { get; set; }

    
    public List<Umidade> Umidades { get; set; } = new();
    public List<GranulometriaCompleta> GranulometriaCompleta { get; set; } = new();
}


