using Application.Contracts;
using Application.DTOs.Cinema.Validators;
using Application.Features.Cinemas.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Handlers.Commands
{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICinemaRepository _cinemaRepository;
        public CreateCinemaCommandHandler(ICinemaRepository cinemaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateCinemaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCinemaDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var cinema = _mapper.Map<Cinema>(request.CreateCinemaDto);
            cinema = await _cinemaRepository.Add(cinema);
            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = cinema.Id;

            return response;
        }
    }
}
