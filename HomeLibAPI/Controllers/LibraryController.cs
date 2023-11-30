using HomeLibAPI.Services;
using HomeLibraryAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Controllers
{
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly HomeLibraryDbContext _dbContext;
        private readonly ILibraryElementService _libraryElementService;
        public LibraryController(HomeLibraryDbContext dbContext, ILibraryElementService libraryElementService)
        {
            _dbContext = dbContext;
            _libraryElementService = libraryElementService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _dbContext
                .Books
                .Include(r => r.Author)
                .Include(r => r.Publisher)
                .ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> Get([FromRoute] int id)
        {
            var book = _dbContext
                .Books
                .Include(r => r.Author)
                .Include(r => r.Publisher)
                .FirstOrDefault(r => r.Id == id);

            if(book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
