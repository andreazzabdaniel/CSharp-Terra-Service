using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace terraservice.Domain.Entities;

public class Clients
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDelited { get; set; } = false;
    
        
    public List<Projects> Projects { get; set; } = new();
}