namespace terraservice.Domain.Repositories.Umidade;

public interface IUmidadeWriteOnlyRepository
{
    Task CreateCalculateUmidade(Entities.Ensaios.Umidade umidade);
    Task CreateUmidade(Entities.Ensaios.Umidade umidade);
    Task DeleteUmidade(int umidadeId);
}