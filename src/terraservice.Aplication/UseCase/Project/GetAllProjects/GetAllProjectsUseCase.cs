using AutoMapper;
using terraservice.Communication.Project.Response;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Domain.Repositories.Projects;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;
using Projects = terraservice.Domain.Entities.Projects;

namespace terraservice.Aplication.UseCase.Project.GetAllProjects;

public class GetAllProjectsUseCase : IGetAllProjectsUseCase
{
    
    /// <summary>
    /// TODO = Refazer esse endpoint pois o isProjectExist foi refeito e agora não retorna o project ele retorna uma lista de nomes somente
    /// </summary>
    /// 
    private readonly IProjectReadOnlyRepository _projectRepo;
    private readonly IClientReadOnlyRepository _clientRepo;
    private readonly IMapper _mapper;
    
    public GetAllProjectsUseCase(
        IProjectReadOnlyRepository projectRepo,
        IClientReadOnlyRepository clientRepo,
        IMapper mapper)
    {
        _projectRepo = projectRepo;
        _clientRepo = clientRepo;
        _mapper = mapper;
    }
    public async Task<ResponseAllProjectsJson> Execute(int clientId)
    {
        var isClientExists = await _clientRepo.FindClientById(clientId);
        if (isClientExists is null)
        {
            throw new NotFountException(ResourceErrorMessages.CLIENT_DOESENT_EXIST);
        }
        
        var projects =  await _projectRepo.IsProjectExist(clientId);
        return new ResponseAllProjectsJson
        {
            ListProjects = _mapper.Map<List<ProjectsDto>>(projects)
        };
    }
}