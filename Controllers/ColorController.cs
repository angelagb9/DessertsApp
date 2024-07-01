using DessertsApp.Commands.ColorCommands.CreateColor;
using DessertsApp.Exceptions;
using DessertsApp.Queries.ColorQueries.GetColorById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DessertsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private IMediator _mediator;
        public ColorController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateColorCommand command)
        {
            try 
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Data);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetColorByIdQuery{ Id = id };
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
