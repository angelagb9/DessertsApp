using DessertsApp.Commands.ColorCommands.CreateColor;
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
    }
}
