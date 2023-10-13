using Application.DTOs.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Requests.Commands
{
    public class UpdateMovieCommand : IRequest<Unit>
    {
        public UpdateMovieDto UpdateMovieDto { get; set; }
    }
}
