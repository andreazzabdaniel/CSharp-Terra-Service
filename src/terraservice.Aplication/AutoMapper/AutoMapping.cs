using AutoMapper;
using terraservice.Communication.Client.Request;
using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Communication.MassaEspecifica.Response;
using terraservice.Communication.Point.Request;
using terraservice.Communication.Point.Response;
using terraservice.Communication.Project.Request;
using terraservice.Communication.Project.Response;
using terraservice.Communication.Umidade.Request;
using terraservice.Communication.Umidade.Response;
using terraservice.Communication.UmidadeCompleta.Request;
using terraservice.Communication.User;
using terraservice.Domain.Entities;
using terraservice.Domain.Entities.Ensaios;
using Projects = terraservice.Domain.Entities.Projects;

namespace terraservice.Aplication.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<SingInRequestJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
       
        CreateMap<RequestCreateClientJson, Clients>()
            .ForMember(dest => dest.ClientId, config => config.Ignore());
        
        CreateMap<RequestCreateProjectJson, Projects>();

        CreateMap<RequestCreatePointJson, Points>();

        CreateMap<RequestCalculateUmidadeJson, Umidade>();

        CreateMap<RequestCreateGranulometriaCompletaJson, GranulometriaCompleta>();

        CreateMap<RequestCreateMassaEspecificaJson, MassaEspecifica>();
        CreateMap<RequestCalculateMassaEspecificaJson, MassaEspecifica>();
    }
    private void EntityToResponse()
    {
        CreateMap<Projects, ProjectsDto>();
        CreateMap<List<Projects>, ResponseAllProjectsJson>()
            .ForMember(dest => dest.ListProjects, opt => opt.MapFrom(src => src));

        CreateMap<Points, PointDto>();
        CreateMap<List<Points>, ResponseAllPointsJson>()
            .ForMember(dest => dest.ListPoints, opt => opt.MapFrom(src => src));

        CreateMap<Umidade, UmidadeDto>();
        CreateMap<List<Umidade>, ResponseAllUmidadeJson>()
            .ForMember(dest => dest.AllUmidades, opt => opt.MapFrom(src => src));

        CreateMap<Umidade, ResponseUmidadeJson>();

        CreateMap<MassaEspecifica, ResponseGetMassaEspecificaJson>();
    }
}