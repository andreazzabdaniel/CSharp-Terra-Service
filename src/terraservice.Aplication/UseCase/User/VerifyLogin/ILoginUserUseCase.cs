using terraservice.Communication.User;
using terraservice.Communication.User.Response;

namespace terraservice.Aplication.UseCase.User.VerifyLogin;

public interface ILoginUserUseCase
{
    Task<ResponseVerifyedUserJson> Execute(LoginRequestJson request);
}