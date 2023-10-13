using Application.DTOs.Cinema;
using Application.DTOs.Movie;
using AutoMapper;
using Domain;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, UpdateMovieDto>().ReverseMap();
            CreateMap<Movie, CreateMovieDto>().ReverseMap();

            CreateMap<Cinema, CinemaDto>().ReverseMap();
            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();
            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();
        }
    }
}
