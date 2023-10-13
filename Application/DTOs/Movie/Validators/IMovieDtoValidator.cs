using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Movie.Validators
{
    public class IMovieDtoValidator : AbstractValidator<IMovieDto>
    {
        public IMovieDtoValidator() 
        {
            RuleFor(movie => movie.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(movie => movie.Release_date)
                .NotEmpty().WithMessage("Release date is required.")
                .Must(date => date != DateTime.MinValue).WithMessage("Invalid release date.");

            RuleFor(movie => movie.Duration)
                .GreaterThan(0).WithMessage("Duration must be a positive integer.")
                .LessThanOrEqualTo(300).WithMessage("Duration must not exceed 300 minutes.");

            RuleFor(movie => movie.Genre)
                .NotEmpty().WithMessage("Genre is required.")
                .MaximumLength(50).WithMessage("Genre must not exceed 50 characters.");

            RuleFor(movie => movie.Director)
                .NotEmpty().WithMessage("Director is required.")
                .MaximumLength(100).WithMessage("Director's name must not exceed 100 characters.");

            RuleFor(movie => movie.Rating)
                .Must(rating => rating >= 0 && rating <= 10)
                .WithMessage("Rating must be between 0 and 10.")
                .Must(rating => Math.Round(rating, 2) == rating)
                .WithMessage("Rating must have up to 2 decimal places.");
        } 
    }
}
