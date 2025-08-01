using AutoMapper;
using terraservice.Aplication.UseCase._00___Geral;
using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Communication.MassaEspecifica.Response;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.MassaEspecifica;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.MassaEspecifica.CalculateMassaEspecifica;

public class CalculateMassaEspecificaUseCase : ICalculateMassaEspecificaUseCase
{
    private readonly IMapper _mapper;
    private readonly IMassaEspecificaReadOnlyRepository _readMassaRepo;
    private readonly IMassaEspecificaWriteOnlyRepository _writeMassaRepo;
    private readonly IUnityOfWork _unityOfWork;
    public CalculateMassaEspecificaUseCase(
        IMapper mapper,
        IMassaEspecificaReadOnlyRepository readMassaRepo,
        IMassaEspecificaWriteOnlyRepository writeMassaRepo,
        IUnityOfWork unityOfWork
        )
    {
        _mapper = mapper;
        _readMassaRepo = readMassaRepo;
        _writeMassaRepo = writeMassaRepo;
        _unityOfWork = unityOfWork;
    }
    
    
    public async Task<ResponseCalculateMassaEspecificaJson> Execute(RequestCalculateMassaEspecificaJson request)
    {
        Validator(request);
        var resultado = Calculate(request);

        var massaEspecifica = await _readMassaRepo.GetMassaEspecifica(request.MassaEspecificaId);
        if (massaEspecifica is null)
        {
            throw new NotFountException(ResourceErrorMessages.NOT_FOUND);
        }

        _mapper.Map(request, massaEspecifica);
        massaEspecifica.MassaEspecificaIndividual = resultado.MassaEspecificaIndividual;
        massaEspecifica.MassaEspecificaMedia = resultado.MassaEspecificaMedia;

        _writeMassaRepo.CreateCalculo(massaEspecifica);
        await _unityOfWork.Commit();
        
        return new ResponseCalculateMassaEspecificaJson
        {
            MassaEspecificaIndividual = resultado.MassaEspecificaIndividual,
            MassaEspecificaMedia = resultado.MassaEspecificaMedia
        };
    }
    
    private void Validator(RequestCalculateMassaEspecificaJson request)
    {
        var result = new CalculateMassaEspecificaValidator().Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
    
    private (List<float> MassaEspecificaIndividual, float MassaEspecificaMedia) Calculate(RequestCalculateMassaEspecificaJson request)
    {
        var PICTOMETRO_MAIS_AGUA = 638.38;
        
        var calculadora = new MassaEspecificaAguaPelaTemperatura();
        var massaAgua = calculadora.CalculateDensidadeAgua(request.Temperaturas);

        List<float> massaEspecificaIndividual = new List<float>();

        for (int i = 0; i < request.MassaSolo.Count; i++)
        {
            var massaSeca = request.MassaSolo[i] * (100f / (100f + request.Umidade));
            var resultado = (massaSeca / (massaSeca + PICTOMETRO_MAIS_AGUA - request.MassaSolo[i])) * massaAgua[i];

            massaEspecificaIndividual.Add((float)resultado);
        }

        var massaEspecificaMedia = massaEspecificaIndividual.Average();

        return (massaEspecificaIndividual, massaEspecificaMedia);
    }
}