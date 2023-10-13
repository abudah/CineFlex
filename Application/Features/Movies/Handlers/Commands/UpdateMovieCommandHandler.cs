using Application.Contracts;
using Application.DTOs.Movie.Validators;
using Application.Exceptions;
using Application.Features.Movies.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMovieDtoValidator(_movieRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateMovieDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var movie = await _movieRepository.Get(request.UpdateMovieDto.Id);
            _mapper.Map(request.UpdateMovieDto, movie);
            await _movieRepository.Update(movie);
            return Unit.Value;
        }
    }
}
