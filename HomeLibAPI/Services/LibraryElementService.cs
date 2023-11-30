using HomeLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Services
{
    public interface ILibraryElementService
    {

    }
    public class LibraryElementService : ILibraryElementService
    {
        private readonly HomeLibraryDbContext _dbContext;
        public LibraryElementService(HomeLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
