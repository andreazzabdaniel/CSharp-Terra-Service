namespace terraservice.Aplication.UseCase.MassaEspecifica.DeleteMassaEspecifica;

public interface IDeleteMassaEspecificaUseCase
{
    Task Execute(int massaEspecificaId);
}