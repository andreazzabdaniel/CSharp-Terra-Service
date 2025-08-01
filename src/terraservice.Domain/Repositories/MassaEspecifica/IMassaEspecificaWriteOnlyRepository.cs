namespace terraservice.Domain.Repositories.MassaEspecifica;

public interface IMassaEspecificaWriteOnlyRepository
{
    Task Create(Entities.Ensaios.MassaEspecifica request);
    void CreateCalculo(Entities.Ensaios.MassaEspecifica request);
    Task SoftDelite(int massaEspecificaId);
}