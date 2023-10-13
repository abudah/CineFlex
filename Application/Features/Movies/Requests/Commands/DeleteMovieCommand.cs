using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Requests.Commands
{
    public class DeleteMovieCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
