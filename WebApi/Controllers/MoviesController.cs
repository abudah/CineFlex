using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Commands;
using Application.Features.Movies.Requests.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<ActionResult<Movie>> Get()
        {
            var movies = await _mediator.Send(new GetMovieListRequest());
            return Ok(movies);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _mediator.Send(new GetMovieDetailRequest { Id = id });
            return Ok(movie);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMovieDto Movie)
        {
            var command = new CreateMovieCommand { CreateMovieDto = Movie };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<MoviesController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateMovieDto Movie)
        {
            var command = new UpdateMovieCommand { UpdateMovieDto = Movie };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(MovieDto Movie)
        {
            var command = new DeleteMovieCommand { Id = Movie.Id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}