
using Application.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Commands;
using Application.Features.Cinemas.Requests.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CinemasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<CinemasController>
        [HttpGet]
        public async Task<ActionResult<Movie>> Get()
        {
            var cinemas = await _mediator.Send(new GetCinemaListRequest());
            return Ok(cinemas);
        }

        // GET api/<CinemasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var cinema = await _mediator.Send(new GetCinemaDetailRequest { Id = id });
            return Ok(cinema);
        }

        // POST api/<CinemasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCinemaDto Cinema)
        {
            var command = new CreateCinemaCommand { CreateCinemaDto = Cinema };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CinemasController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto Cinema)
        {
            var command = new UpdateCinemaCommand { UpdateCinemaDto = Cinema };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CinemasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(CinemaDto Cinema)
        {
            var command = new DeleteCinemaCommand { Id = Cinema.Id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}