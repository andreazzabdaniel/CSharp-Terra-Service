using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Points;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Point.DeletePoints;

public class DeletePointsUseCase : IDeletePointsUseCase
{
    private readonly IPointReadOnlyRepository _readOnly;
    private readonly IPointWriteOnlyRepository _writeOnly;
    private readonly IUnityOfWork _unityOfWork;
    public DeletePointsUseCase(
        IPointReadOnlyRepository readOnly,
        IPointWriteOnlyRepository writeOnly,
        IUnityOfWork unityOfWork)
    {
        _readOnly = readOnly;
        _writeOnly = writeOnly;
        _unityOfWork = unityOfWork;
    }
    public async Task Execute(int pointId)
    {
        var isPointExist = await _readOnly.IsPointExist(pointId);
        if (isPointExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        await _writeOnly.SoftDelitePoint(pointId);
        await _unityOfWork.Commit();
    }
}