using Application.Contracts;
using Application.DTOs.Movie.Validators;
using Domain;
using Application.Responses;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Movies.Requests.Commands;

namespace Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateMovieDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateMovieDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var movie = _mapper.Map<Movie>(request.CreateMovieDto);
            movie  = await _movieRepository.Add(movie);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = movie.Id;

            return response;
        }
    }
}
