using Application.DTOs.Movie;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<BaseCommandResponse>
    {
        public CreateMovieDto CreateMovieDto { get; set; }
    }
}
