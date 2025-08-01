namespace terraservice.Domain.Repositories.Projects;

public interface IProjectWriteOnlyRepository
{
    Task SaveProject(Entities.Projects projeto);
    Task DeliteProject(int projectId);
    Task UpdateName(string name, int projectId);
}