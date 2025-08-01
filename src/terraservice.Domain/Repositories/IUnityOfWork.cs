namespace terraservice.Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}