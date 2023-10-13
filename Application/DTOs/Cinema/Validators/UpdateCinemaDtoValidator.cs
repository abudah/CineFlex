using Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cinema.Validators
{
    public class UpdateCinemaDtoValidator : AbstractValidator<UpdateCinemaDto>  
    {
        private readonly ICinemaRepository _cinemaRepository;
        public UpdateCinemaDtoValidator(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;

            Include(new ICinemaDtoValidator());

            RuleFor(cinema => cinema.Id)
                .NotNull().WithMessage("Id must be present")
                .MustAsync(async (id, token) =>
                {
                    var cinema = await _cinemaRepository.Get(id);
                    return cinema != null;
                });

        }

    }
}
