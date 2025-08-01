namespace terraservice.Domain.Repositories.Points;

public interface IPointWriteOnlyRepository
{
    Task CreatePoint(Entities.Points point);
    Task SoftDelitePoint(int pointId);
}