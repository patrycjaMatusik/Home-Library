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
        public LibraryController(HomeLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            var books = _dbContext
                .Books
                .Include(r => r.Author)
                .Include(r => r.Publisher)
                .Include(r => r.Keywords)
                .ThenInclude(r => r.Name)
                .ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> Get([FromRoute] int id)
        {
            var book = _dbContext.Books.FirstOrDefault(r => r.Id == id);

            if(book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
