using Application.DTOs.Cinema;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Requests.Commands
{
    public class UpdateCinemaCommand : IRequest<Unit>
    {
        public UpdateCinemaDto UpdateCinemaDto { get; set; }
    }
}
