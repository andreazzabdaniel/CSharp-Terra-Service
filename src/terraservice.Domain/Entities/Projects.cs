using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace terraservice.Domain.Entities;

public class Projects
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public bool IsDelited { get; set; } = false;

    public int ClientId { get; set; }
    public Clients Client { get; set; }

    public List<Points> Point { get; set; } = new();
}