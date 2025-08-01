using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.User.SingIn;
using terraservice.Aplication.UseCase.User.VerifyLogin;
using terraservice.Communication;
using terraservice.Communication.User;
using terraservice.Communication.User.Response;

namespace terraservice.api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : Controller
{
    
    [HttpPost("login")]
    [ProducesResponseType(typeof(ResponseVerifyedUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestJson request,
        [FromServices]ILoginUserUseCase useCase
    )
    {
        var response = await useCase.Execute(request);
        
        return Ok(response);
    }
    
    
    [HttpPost("singin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SingIn(
        [FromBody] SingInRequestJson request,
        [FromServices]ISingInUser useCase
    )
    {
        await useCase.Execute(request);

        return Created();
    }
}