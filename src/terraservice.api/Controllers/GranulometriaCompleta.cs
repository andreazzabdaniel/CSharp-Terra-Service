using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.GranulometriaCompleta.CreateGranulometriaCompleta;
using terraservice.Communication.UmidadeCompleta.Request;

namespace terraservice.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GranulometriaCompleta : Controller
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] RequestCreateGranulometriaCompletaJson request,
            [FromServices] ICreateGranulometriaCompletaUseCase useCase
        )
        {
            await useCase.Execute(request);
        
            return Ok();
        }
        
        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate(
            [FromBody] RequestCreateGranulometriaCompletaJson request,
            [FromServices] ICreateGranulometriaCompletaUseCase useCase
        )
        {
            await useCase.Execute(request);
        
            return Ok();
        }
    }
}
