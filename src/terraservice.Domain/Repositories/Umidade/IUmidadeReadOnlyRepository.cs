namespace terraservice.Domain.Repositories.Umidade;

public interface IUmidadeReadOnlyRepository
{
    Task<bool> VerifyIfNameAlredyExist(string name);
    Task<Entities.Ensaios.Umidade> GetUmidade(int umidadeId);
    Task<bool> IsUmidadeExist(int umidadeId);
    Task<bool> IsNameAlredyExist(string name);
    Task<List<Entities.Ensaios.Umidade>> GetAllUmidade(int pointId);
    Task<List<string>> GetAllNamesByPointId(int pointId);
}