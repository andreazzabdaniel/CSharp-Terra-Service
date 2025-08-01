using AutoMapper;
using FluentValidation.Results;
using terraservice.Communication.Umidade.Request;
using terraservice.Communication.Umidade.Response;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Points;
using terraservice.Domain.Repositories.Umidade;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.Umidade.CalculateUmidade;

public class CalculateUmidadeUseCase : ICalculateUmidadeUseCase
{
    private readonly IUmidadeReadOnlyRepository _readUmidadeRepo;
    private readonly IUmidadeWriteOnlyRepository _writeUmidadeRepo;
    private readonly IPointReadOnlyRepository _readPointsRepo;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    
    public CalculateUmidadeUseCase(
        IUmidadeReadOnlyRepository readUmidadeRepo,
        IUmidadeWriteOnlyRepository writeUmidadeRepo,
        IPointReadOnlyRepository readPointsRepo,
        IUnityOfWork unityOfWork,
        IMapper mapper)
    {
       _readUmidadeRepo = readUmidadeRepo;
       _writeUmidadeRepo = writeUmidadeRepo;
       _readPointsRepo = readPointsRepo;
       _unityOfWork = unityOfWork;
       _mapper = mapper;    
    }
    
    public async Task<ResponseCalculateUmidadeJson> Execute(RequestCalculateUmidadeJson request)
    {
        await Validator(request);
        
        var calculos = Calculate(request);

        var umidade = _mapper.Map<Domain.Entities.Ensaios.Umidade>(request);
        umidade.Result = calculos.resultados;
        umidade.ResultMedia = calculos.media;

        await _writeUmidadeRepo.CreateUmidade(umidade);
        await _unityOfWork.Commit();

        return new ResponseCalculateUmidadeJson()
        {
            Resultados = umidade.Result,
            Media = umidade.ResultMedia
        };
    }

    private async Task Validator(RequestCalculateUmidadeJson request)
    {
        var pointExist = await _readUmidadeRepo.IsUmidadeExist(request.UmidadeId);
        if (pointExist is false)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }
        
        var result = new CalculateUmidadeValidator().Validate(request);
        
        var nameAlredyExist = await _readUmidadeRepo.VerifyIfNameAlredyExist(request.Name);
        if (nameAlredyExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.NAME_EXIST));
        }
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }

    private (List<float> resultados, float media) Calculate(RequestCalculateUmidadeJson request)
    {
        var resultados = new List<float>();

        for (int i = 0; i < request.Capsula.Count; i++)
        {
            var calculoUmidade = 
                (request.SoloMaisCapsula[i] - request.SoloSecoMaisCapsula[i]) / 
                (request.SoloSecoMaisCapsula[i] - request.Tara[i]) * 100;
            
            resultados.Add(calculoUmidade);
        }

        var media = resultados.Average();

        return (resultados, media);
    }
}