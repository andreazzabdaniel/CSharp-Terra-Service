namespace terraservice.Domain.Repositories.GranulometriaCompleta;

public interface IGranulometriaCompletaReadOnlyRepository
{
    Task<bool> IsNameAlredyExist(string name);
}