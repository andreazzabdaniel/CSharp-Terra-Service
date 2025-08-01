using Microsoft.EntityFrameworkCore;
using terraservice.Domain.Entities;
using terraservice.Domain.Entities.Ensaios;

namespace terraservice.Infrastructure.DataAccess;

public class TerraserviceDbContext : DbContext
{
    public TerraserviceDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Clients> Clients { get; set; }
    public DbSet<Projects> Projects { get; set; }
    public DbSet<Points> Points { get; set; }
    public DbSet<Umidade> Umidade { get; set; }
    public DbSet<GranulometriaCompleta> GranulometriaCompleta { get; set; }
    public DbSet<MassaEspecifica> MassaEspecifica { get; set; }
}