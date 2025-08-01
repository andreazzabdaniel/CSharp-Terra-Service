namespace terraservice.Domain.Repositories.MassaEspecifica;

public interface IMassaEspecificaReadOnlyRepository
{
    Task<bool> IsNameAlredyExist(string name);
    Task<Entities.Ensaios.MassaEspecifica> GetMassaEspecifica(int massaEspecificaId);
    Task<bool> IsIdExists(int massaEspecificaId);
    Task<List<string>> GetAllNamesByPointId(int pointId);
}