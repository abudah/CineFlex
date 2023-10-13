using Application.Contracts;
using Application.DTOs.Cinema;
using Application.Features.Cinemas.Requests.Queries;
using Application.Features.Movies.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Queries
{
    public class GetCinemaListRequestHandler : IRequestHandler<GetCinemaListRequest, List<CinemaDto>>
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMapper _mapper;

        public GetCinemaListRequestHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<List<CinemaDto>> Handle(GetCinemaListRequest request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.GetAll();

            return _mapper.Map<List<CinemaDto>>(cinema);
        }
    }
}
