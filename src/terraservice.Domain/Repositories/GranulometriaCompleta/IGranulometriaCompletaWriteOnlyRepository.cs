namespace terraservice.Domain.Repositories.GranulometriaCompleta;

public interface IGranulometriaCompletaWriteOnlyRepository
{
    Task CreateGranulometriaCompleta(Entities.Ensaios.GranulometriaCompleta request);
}