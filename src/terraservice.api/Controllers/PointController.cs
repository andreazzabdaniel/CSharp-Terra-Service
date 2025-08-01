using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.MassaEspecifica.GetMassaEspecifica;
using terraservice.Aplication.UseCase.Point.CreatePoint;
using terraservice.Aplication.UseCase.Point.DeletePoints;
using terraservice.Aplication.UseCase.Point.GetAll;
using terraservice.Communication;
using terraservice.Communication.Point.Request;
using terraservice.Communication.Point.Response;

namespace terraservice.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointController : Controller
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponsePointJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreatePointUseCase useCase,
            [FromBody] RequestCreatePointJson request
        )
        {
            var result = await useCase.Execute(request);
            
            return Created(string.Empty, result);
        }
        
        
        [HttpDelete("delite")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delite(
            [FromServices] IDeletePointsUseCase useCase,
            [FromBody] int pointId
        )
        {
            await useCase.Execute(pointId);
            
            return NoContent();
        }
        
        
        [HttpGet("getall")]
        [ProducesResponseType(typeof(ResponseAllPointsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUseCase useCase,
            [FromBody] int projectId
        )
        {
            var result = await useCase.Execute(projectId);
            
            return Ok(result);
        }


        [HttpGet("getbyid")]
        [ProducesResponseType(typeof(ResponseGetPointJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromBody] int pointId,
            [FromServices] IGetMassaEspecificaUseCase useCase)
        {
            await useCase.Execute(pointId);
            
            
            return NoContent();
        }
        
        
    }
}
