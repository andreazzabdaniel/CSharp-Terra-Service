using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.MassaEspecifica.CalculateMassaEspecifica;
using terraservice.Aplication.UseCase.MassaEspecifica.CreateMassaEspecifica;
using terraservice.Aplication.UseCase.MassaEspecifica.DeleteMassaEspecifica;
using terraservice.Aplication.UseCase.MassaEspecifica.GetMassaEspecifica;
using terraservice.Communication;
using terraservice.Communication.MassaEspecifica.Request;
using terraservice.Communication.MassaEspecifica.Response;

namespace terraservice.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MassaEspecificaController : Controller
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseMassaEspJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] RequestCreateMassaEspecificaJson request,
            [FromServices] ICreateMassaEspecificaUseCase useCase
        )
        {
            var result = await useCase.Execute(request);
        
            return Created(string.Empty, result);
        }
        
        
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromBody] int id,
            [FromServices] IDeleteMassaEspecificaUseCase useCase
        )
        {
            await useCase.Execute(id);
        
            return NoContent();
        }


        [HttpGet("getensaio")]
        [ProducesResponseType(typeof(ResponseGetMassaEspecificaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEnsaio(
            [FromBody] int massaEspecificaId,
            [FromServices] IGetMassaEspecificaUseCase useCase)
        {
            var result = await useCase.Execute(massaEspecificaId);
            
            return Ok(result);
        }
        
        
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(ResponseCalculateMassaEspecificaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Calculate(
            [FromBody] RequestCalculateMassaEspecificaJson request,
            [FromServices] ICalculateMassaEspecificaUseCase useCase
        )
        {
            var result = await useCase.Execute(request);
        
            return Ok(result);
        }
        
    }
}
