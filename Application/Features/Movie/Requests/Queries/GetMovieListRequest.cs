using Application.DTOs.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movie.Requests.Queries
{
    public class GetMovieListRequest : IRequest<List<MovieDto>>
    {
    }
}
