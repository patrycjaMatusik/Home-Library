using AutoMapper;
using HomeLibAPI.Models;
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
        private readonly IMapper _mapper;
        public LibraryController(HomeLibraryDbContext dbContext, ILibraryElementService libraryElementService, IMapper mapper)
        {
            _dbContext = dbContext;
            _libraryElementService = libraryElementService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LibraryElementDto>> GetAll()
        {
            var libraryElementsDtos = _libraryElementService.GetAll();

            return Ok(libraryElementsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<LibraryElementDto>> Get([FromRoute] int id)
        {
            var libraryElement = _libraryElementService.GetById(id);

            return Ok(libraryElement);
        }

        [HttpGet("keywords")]
        public ActionResult<IEnumerable<KeywordDto>> GetAllKeywords()
        {
            var keywords = _dbContext
                .Keyword
                .ToList();

            var keywordDtos = _mapper.Map<List<KeywordDto>>(keywords);

            return Ok(keywordDtos);
        }

        [HttpPost("book")]
        public ActionResult CreateBook([FromBody] CreateBookDto dto)
        {
            var id = _libraryElementService.CreateBook(dto);

            return Created($"/api/library/{id}", null);
        }

        [HttpPut("book/{id}")]
        public ActionResult Update([FromBody] UpdateBookDto dto, [FromRoute] int id)
        {

            _libraryElementService.UpdateBook(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _libraryElementService.Delete(id);

            return NoContent();
        }
    }
}
