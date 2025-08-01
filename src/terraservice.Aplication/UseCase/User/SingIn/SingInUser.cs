using AutoMapper;
using FluentValidation.Results;
using terraservice.Communication.User;
using terraservice.Domain.Repositories;
using terraservice.Domain.Repositories.Users;
using terraservice.Domain.Security.Criptography;
using terraservice.Exception;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.User.SingIn;

public class SingInUser : ISingInUser
{
    private readonly IMapper _mapper;
    private readonly IEncriptPassword _encript;
    private readonly IUsersReadOnlyRepository _repoReadOnly;
    private readonly IUsersWriteOnlyRepository _repoWriteOnly;
    private readonly IUnityOfWork _unityOfWork;
    

    public SingInUser(
        IMapper mapper, 
        IEncriptPassword encript,
        IUsersWriteOnlyRepository repoWriteOnly,
        IUsersReadOnlyRepository repoReadOnly,
        IUnityOfWork unityOfWork)
    {
        _mapper = mapper;
        _encript = encript;
        _repoWriteOnly = repoWriteOnly;
        _repoReadOnly = repoReadOnly;
        _unityOfWork = unityOfWork;
    }
    public async Task Execute(SingInRequestJson request)
    {
        await Validate(request);
        
        var user = _mapper.Map<Domain.Entities.User>(request);
        user.Password = _encript.Encript(request.Password);
        user.UserId = new Guid();

        await _repoWriteOnly.RegisterUser(user);
        await _unityOfWork.Commit();
    }

    private async Task Validate(SingInRequestJson request)
    {
        var result = new SingInUserValidator().Validate(request);

        var emailExists = await _repoReadOnly.VerifyIfEmailExists(request.Email);

        if (emailExists)
        {
            result.Errors.Add(new ValidationFailure(string.Empty,ResourceErrorMessages.EMAIL_ALREDY_EXISTS));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}