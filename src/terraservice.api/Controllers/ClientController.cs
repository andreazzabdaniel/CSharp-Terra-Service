using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.Client.CreateClient;
using terraservice.Aplication.UseCase.Client.DeliteClient;
using terraservice.Aplication.UseCase.Client.GetAllClients;
using terraservice.Aplication.UseCase.Client.GetClient;
using terraservice.Aplication.UseCase.Client.UpdateClient;
using terraservice.Communication;
using terraservice.Communication.Client.Request;
using terraservice.Communication.Client.Response;

namespace terraservice.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] RequestCreateClientJson request,
            [FromServices] ICreateClientUseCase useCase
        )
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }


        [HttpDelete("delite")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delite(
            [FromBody] int id,
            [FromServices] IDeliteClientUseCase useCase
        )
        {
            await useCase.Execute(id);

            return NoContent();
        }


        [HttpGet("getall")]
        [ProducesResponseType(typeof(ResponseGetAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllClientUseCase useCase
        )
        {
            var result = await useCase.Execute();

            if (result.AllClients.Count != 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
        
        
        [HttpGet("getclient")]
        [ProducesResponseType(typeof(ResponseGetClientByIdJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetClient(
            [FromBody] int clientId,
            [FromServices] IGetClientByIdUseCase useCase
        )
        {
            var result = await useCase.Execute(clientId);

            if (result.Projects.Count != 0)
                return Ok(result);

            return NoContent();
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            [FromBody] RequestUpdateClientJson request,
            [FromServices] IUpdateClientUseCase useCase
        )
        {
            await useCase.Execute(request);

            return NoContent();
        }

    }
}