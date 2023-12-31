﻿using Application.DTOs.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Movies.Requests.Queries
{
    public class GetMovieDetailRequest : IRequest<MovieDto>
    {
        public int Id { get; set; } 
    }
}
