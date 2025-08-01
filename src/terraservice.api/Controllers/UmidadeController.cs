using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.Umidade.CalculateUmidade;
using terraservice.Aplication.UseCase.Umidade.CreateUmidade;
using terraservice.Aplication.UseCase.Umidade.DeleteUmidade;
using terraservice.Aplication.UseCase.Umidade.GetAllUmidade;
using terraservice.Aplication.UseCase.Umidade.GetUmidade;
using terraservice.Communication;
using terraservice.Communication.Umidade.Request;
using terraservice.Communication.Umidade.Response;

namespace terraservice.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UmidadeController : Controller
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseCreateUmidadeJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateUmidadeUseCase useCase,
            [FromBody] RequestCreateUmidadeJson request
        )
        {
            var result = await useCase.Execute(request);
            
            return Created(string.Empty, result);
        }


        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUmidade(
            [FromBody] int umidadeId,
            [FromServices] IDeleteUmidadeUseCase useCase)
        {
            await useCase.Execute(umidadeId);
            
            return NoContent();
        }
        
        
        [HttpGet("getall")]
        [ProducesResponseType(typeof(ResponseAllUmidadeJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromBody] int request,
            [FromServices] IGetAllUmidadeUseCase useCase
        )
        {
            var response = await useCase.Execute(request);
            
            if(response.AllUmidades.Count != 0)
                return Ok(response);

            return NoContent();
        }
        
        
        [HttpGet("getumidade")]
        [ProducesResponseType(typeof(ResponseUmidadeJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUmidadeById(
            [FromBody] int umidadeId,
            [FromServices] IGetUmidadeUseCase useCase
        )
        {
            var response = await useCase.Execute(umidadeId);
            
            return Ok(response);
        }
        
        
        [HttpPost("calculate")]
        [ProducesResponseType(typeof(ResponseCalculateUmidadeJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Calculate(
            [FromBody] RequestCalculateUmidadeJson request,
            [FromServices] ICalculateUmidadeUseCase useCase
        )
        {
            var result = await useCase.Execute(request);
        
            return Ok(result);
        }
    }
}
