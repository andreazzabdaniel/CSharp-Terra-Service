
using Microsoft.AspNetCore.Mvc;
using terraservice.Aplication.UseCase.Project.CreateProject;
using terraservice.Aplication.UseCase.Project.DeliteProject;
using terraservice.Aplication.UseCase.Project.GetAllProjects;
using terraservice.Aplication.UseCase.Project.GetByIdProject;
using terraservice.Aplication.UseCase.Project.UpdateProject;
using terraservice.Communication;
using terraservice.Communication.Project.Request;
using terraservice.Communication.Project.Response;

namespace terraservice.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        [HttpPost("create")]
        [ProducesResponseType(typeof(ResponseProjectJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(
            [FromBody] RequestCreateProjectJson request,
            [FromServices] ICreateProjectUseCase useCase
        )
        {
            var result = await useCase.Execute(request);
            
            return Created(string.Empty, result);
        }
        
        
        [HttpDelete("delite")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeliteProjectById(
            [FromBody] int projectId,
            [FromServices] IDeliteProjectById useCase
        )
        {
            await useCase.Execute(projectId);
            
            return NoContent();
        }
        
        
        [HttpGet("getall")]
        [ProducesResponseType(typeof(ResponseAllProjectsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllProjects(
            [FromBody] int clientId,
            [FromServices] IGetAllProjectsUseCase useCase
        )
        {
            var response = await useCase.Execute(clientId);

            if (response.ListProjects.Count != 0)
                return Ok(response);
            
            return NoContent();
        }
        
        
        [HttpGet("getbyid")]
        [ProducesResponseType(typeof(ResponseGetProjectJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetById(
            [FromBody] int projectId,
            [FromServices] IGetProjectByIdUseCase useCase
        )
        {
            var response = await useCase.Execute(projectId);

            if (response.Points.Count != 0)
                return Ok(response);
            
            return NoContent();
        }
        
        
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(
            [FromBody] RequestUpdateProjectJson request,
            [FromServices] IUpdateProjectUseCase useCase
        )
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }
    }
}
