using Application.Contracts;
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
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public DeleteMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id);
            if (movie == null)
                throw new NotFoundException(nameof(movie), request.Id);

            await _movieRepository.Delete(movie);

            return Unit.Value;

        }
    }
}
