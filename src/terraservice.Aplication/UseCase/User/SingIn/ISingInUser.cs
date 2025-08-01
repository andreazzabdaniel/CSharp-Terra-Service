using terraservice.Communication.User;
using terraservice.Communication.User.Response;

namespace terraservice.Aplication.UseCase.User.SingIn;

public interface ISingInUser
{
    Task Execute(SingInRequestJson request);
}