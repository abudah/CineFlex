using Application.Contracts;
using Application.Exceptions;
using Application.Features.Cinemas.Requests.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Commands
{
    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;
        public DeleteCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }
        public async Task<Unit> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaRepository.Get(request.Id);
            if (cinema == null)
                throw new NotFoundException(nameof(cinema), request.Id);

            await _cinemaRepository.Delete(cinema.Id);

            return Unit.Value;

        }
    }
}
