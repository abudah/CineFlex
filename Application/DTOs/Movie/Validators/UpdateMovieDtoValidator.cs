using Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Movie.Validators
{
    public class UpdateMovieDtoValidator : AbstractValidator<UpdateMovieDto>
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieDtoValidator(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository; 
            
            Include(new IMovieDtoValidator());

            RuleFor(movie => movie.Id)
                .NotNull().WithMessage("{PropertyName} must be present")
                .MustAsync(async (id, token) =>
                {
                    var movie = await _movieRepository.Get(id);
                    return movie != null;
                });
        }
    }
}
