using Application.Contracts;
using Application.DTOs.Movie;
using Application.Features.Movies.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Handlers.Queries
{
    public class GetMovieListRequestHandler : IRequestHandler<GetMovieListRequest, List<MovieDto>>
        {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieListRequestHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieListRequest request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetAll();

            return _mapper.Map<List<MovieDto>>(movie);
        }
    }
}
