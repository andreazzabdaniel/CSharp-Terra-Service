using terraservice.Domain.Repositories.MassaEspecifica;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.MassaEspecifica.DeleteMassaEspecifica;

public class DeleteMassaEspecificaUseCase : IDeleteMassaEspecificaUseCase
{
    private readonly IMassaEspecificaReadOnlyRepository _readMassaRepo;
    private readonly IMassaEspecificaWriteOnlyRepository _writeMassaRepo;
    public DeleteMassaEspecificaUseCase(
        IMassaEspecificaReadOnlyRepository readMassaRepo,
        IMassaEspecificaWriteOnlyRepository writeMassaRepo)
    {
        _readMassaRepo = readMassaRepo;
        _writeMassaRepo = writeMassaRepo;
    }
    
    public async Task Execute(int massaEspecificaId)
    {
        var massaEspecificaExist = await _readMassaRepo.IsIdExists(massaEspecificaId);
        if (massaEspecificaExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        await _writeMassaRepo.SoftDelite(massaEspecificaId);
    }
    
}