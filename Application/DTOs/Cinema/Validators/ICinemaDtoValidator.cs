using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cinema.Validators
{
    public class ICinemaDtoValidator : AbstractValidator<ICinemaDto>    
    {
        public ICinemaDtoValidator() 
        {
            RuleFor(cinema => cinema.Name)
                .NotEmpty().WithMessage("Cinema name is required.")
                .MaximumLength(100).WithMessage("Cinema name must not exceed 100 characters.");
            RuleFor(cinema => cinema.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
            RuleFor(cinema => cinema.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City must not exceed 50 characters.");
            RuleFor(cinema => cinema.State)
                .NotEmpty().WithMessage("State is required.")
                .MaximumLength(50).WithMessage("State must not exceed 50 characters.");
            RuleFor(cinema => cinema.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");
            RuleFor(cinema => cinema.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be a positive integer.")
                .LessThanOrEqualTo(1000).WithMessage("Capacity must not exceed 1000 seats.");
        }
    }
}
