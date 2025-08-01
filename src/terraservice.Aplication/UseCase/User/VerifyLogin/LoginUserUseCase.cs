using terraservice.Communication.User;
using terraservice.Communication.User.Response;
using terraservice.Domain.Repositories.Users;
using terraservice.Domain.Security.Criptography;
using terraservice.Domain.Security.Token;
using terraservice.Exception.ExceptionBase;

namespace terraservice.Aplication.UseCase.User.VerifyLogin;

public class LoginUserUseCase : ILoginUserUseCase
{
    private readonly IEncriptPassword _encript;
    private readonly IUsersReadOnlyRepository _repository;
    private readonly IAccesTokenGenerator _accesToken;
    public LoginUserUseCase(IEncriptPassword encript, IUsersReadOnlyRepository repository, IAccesTokenGenerator accesToken)
    {
        _encript = encript;
        _repository = repository;
        _accesToken = accesToken;
    }
    
    public async Task<ResponseVerifyedUserJson> Execute(LoginRequestJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);
        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var isValidPassword = _encript.Verify(request.Password, user.Password);
        if (isValidPassword is false)
        {
            throw new InvalidLoginException();
        }
        
        return new ResponseVerifyedUserJson
        {
            Name = user.Name,
            Token = _accesToken.Generate(user)
        };
    }
}