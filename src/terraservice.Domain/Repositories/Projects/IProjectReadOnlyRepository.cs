using terraservice.Domain.Entities;

namespace terraservice.Domain.Repositories.Projects;

public interface IProjectReadOnlyRepository
{
    Task<bool> NameAlredyExist(string name, int clientId);
    Task<bool> IsProjectExist(int projectId);
    Task<List<string>> GetProjectByClientId(int clientId);
    Task<Entities.Projects> GetProjectById(int projectId);
}