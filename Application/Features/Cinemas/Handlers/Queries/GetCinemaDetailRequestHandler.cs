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
    public class GetCinemaDetailRequestHandler : IRequestHandler<GetCinemaDetailRequest, CinemaDto>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;
        public GetCinemaDetailRequestHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = mapper;
        }

        public async Task<CinemaDto> Handle(GetCinemaDetailRequest request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.Get(request.Id);

            return _mapper.Map<CinemaDto>(cinema);
        }
    }
}
