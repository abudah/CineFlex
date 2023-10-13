using Application.DTOs.Cinema;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cinemas.Requests.Commands
{
    public class CreateCinemaCommand : IRequest<BaseCommandResponse>
    {
        public CreateCinemaDto CreateCinemaDto { get; set; }
    }
}
