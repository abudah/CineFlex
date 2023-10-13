using Application.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        private readonly CineFlexDbContext _dbContext;
        public CinemaRepository(CineFlexDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
