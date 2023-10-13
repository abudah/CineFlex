using Application.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly CineFlexDbContext _dbContext;
        public MovieRepository(CineFlexDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
