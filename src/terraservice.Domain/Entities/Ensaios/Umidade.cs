using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace terraservice.Domain.Entities.Ensaios;

[Owned]
public class Umidade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public bool IsDelited { get; set; } = false;
    public List<float> Result { get; set; } = new();
    public float ResultMedia { get; set; }
    
    public int PointId { get; set; }
    public Points Point { get; set; }

    public List<int> Capsula { get; set; } = new();
    public List<float> Tara { get; set; } = new();
    public List<float> SoloMaisCapsula { get; set; } = new();
    public List<float> SoloSecoMaisCapsula { get; set; } = new();
}