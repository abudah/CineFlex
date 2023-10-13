using Application.Contracts;
using Application.DTOs.Cinema.Validators;
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
    public class UpdateCinemaCommandHandler :IRequestHandler<UpdateCinemaCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;
        public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }

        public async Task<Unit> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCinemaDtoValidator(_cinemaRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateCinemaDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var cinema = await _cinemaRepository.Get(request.UpdateCinemaDto.Id);
            _mapper.Map(request.UpdateCinemaDto, cinema);
            await _cinemaRepository.Update(cinema);
            return Unit.Value;
        }
}
}
