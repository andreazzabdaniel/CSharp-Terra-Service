namespace terraservice.Aplication.UseCase.Point.DeletePoints;

public interface IDeletePointsUseCase
{
    Task Execute(int pointId);
}