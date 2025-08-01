namespace terraservice.Aplication.UseCase.Project.DeliteProject;

public interface IDeliteProjectById
{
    Task Execute(int projectId);
}