using Application.Contracts;
using Application.DTOs.Movie;
using Application.Features.Movie.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Handlers.Queries
{
    public class GetMovieDetailRequestHandler : IRequestHandler<GetMovieDetailRequest, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        public GetMovieDetailRequestHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }
        public async Task<MovieDto> Handle(GetMovieDetailRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.Get(request.Id);

            return _mapper.Map<MovieDto>(movie);
        }
    }
}
