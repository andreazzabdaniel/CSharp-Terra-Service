using AutoMapper;
using terraservice.Communication.Point.Request;
using terraservice.Communication.Point.Response;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Point.CreatePoint;

public class CreatePointUseCase : ICreatePointUseCase
{
    private readonly IProjectReadOnlyRepository _projectReadRepo;
    private readonly IPointReadOnlyRepository _pointReadRepo;
    private readonly IPointWriteOnlyRepository _pointWriteRepo;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public CreatePointUseCase(
        IProjectReadOnlyRepository projectReadRepo,
        IPointReadOnlyRepository pointReadRepo,
        IPointWriteOnlyRepository pointWriteRepo,
        IUnityOfWork unityOfWork,
        IMapper mapper)
    {
        _projectReadRepo = projectReadRepo;
        _pointReadRepo = pointReadRepo;
        _pointWriteRepo = pointWriteRepo;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }
    
    public async Task<ResponsePointJson> Execute(RequestCreatePointJson request)
    {
        var isProjectExists = await _projectReadRepo.IsProjectExist(request.ProjectId);
        if (isProjectExists is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var isPointExist = await _pointReadRepo.IsPointAlredyExists(request.Name);
        if (isPointExist is true)
        {
            throw new NotFountException(ResourceErrorMessages.REGISTER_ALREDY_EXISTS);
        }

        var point = _mapper.Map<Points>(request);
        point.StartDate = DateTime.Now;
        point.ModifiedDate = DateTime.Now;

        await _pointWriteRepo.CreatePoint(point);

        await _unityOfWork.Commit();

        return new ResponsePointJson()
        {
            Name = point.Name
        };
    }
}