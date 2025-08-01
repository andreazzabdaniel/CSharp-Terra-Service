namespace terraservice.Domain.Repositories.Points;

public interface IPointReadOnlyRepository
{
    Task<bool> IsPointAlredyExists(string name);
    Task<List<string>> GetAllPoints(int projectId);
    Task<bool> IsPointExist(int pointId);
}