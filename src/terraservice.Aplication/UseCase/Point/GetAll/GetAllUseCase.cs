using AutoMapper;
using terraservice.Communication.Point.Response;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Point.GetAll;

public class GetAllUseCase : IGetAllUseCase
{
    private readonly IPointReadOnlyRepository _readPointRepo;
    private readonly IProjectReadOnlyRepository _readProjectRepo;
    private readonly IMapper _mapper;
    
    public GetAllUseCase(
        IPointReadOnlyRepository readPointRepo,
        IProjectReadOnlyRepository readProjectRepo,
        IMapper mapper)
    {
        _readPointRepo = readPointRepo;
        _readProjectRepo = readProjectRepo;
        _mapper = mapper;
    }
    public async Task<ResponseAllPointsJson> Execute(int projectId)
    {
        var isProjectExist = await _readProjectRepo.IsProjectExist(projectId);
        if (isProjectExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        var points = await _readPointRepo.GetAllPoints(projectId);
        return new ResponseAllPointsJson
        {
            ListPoints = _mapper.Map<List<PointDto>>(points)
        };
    }
}