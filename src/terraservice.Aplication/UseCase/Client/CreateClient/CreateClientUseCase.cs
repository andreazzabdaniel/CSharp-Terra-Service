using System.ComponentModel.DataAnnotations;
using AutoMapper;
using terraservice.Communication.Client.Request;
using terraservice.Communication.Client.Response;
using terraservice.Domain.Entities;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Client;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;
using ValidationException = FluentValidation.ValidationException;

namespace terraservice.Aplication.UseCase.Client.CreateClient;

public class CreateClientUseCase : ICreateClientUseCase
{
    private readonly IClientReadOnlyRepository _readRepo;
    private readonly IClientWriteOnlyRepository _writeRepo;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public CreateClientUseCase(
        IClientReadOnlyRepository readRepo, 
        IClientWriteOnlyRepository writeRepo,
        IUnityOfWork unityOfWork,
        IMapper mapper)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }
    
    public async Task<ResponseClientJson> Execute(RequestCreateClientJson name)
    {
        Validator(name);

        var clientNameExists = await _readRepo.FindIfClientNameAlredyExists(name.ToString());
        if (clientNameExists)
        {
            throw new ErrorOnValidationException(ResourceErrorMessages.CLIENT_NAME_ALREDY_EXISTS);
        }

        var client = _mapper.Map<Clients>(name);

        await _writeRepo.CreateClient(client);
        await _unityOfWork.Commit();

        return new ResponseClientJson()
        {
            Name = client.Name
        };
    }

    private void Validator(RequestCreateClientJson name)
    {
        var isWhiteSpace = string.IsNullOrWhiteSpace(name.ToString());
        if (isWhiteSpace)
        {
            throw new ValidationException(ResourceErrorMessages.CLIENT_NAME_NULL);
        }
    }
}