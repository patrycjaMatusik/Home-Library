using AutoMapper;
using HomeLibAPI.Models;
using HomeLibAPI.Services;
using HomeLibraryAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Controllers
{
    [Route("api/library")]
    public class LibraryController : Controller
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
        [Authorize(Roles = "User, Admin")]
        public ActionResult<IEnumerable<LibraryElementDto>> GetAll([FromQuery] LibraryObjectQuery query)
        {
            var libraryElementsDtos = _libraryElementService.GetAll(query);

            return Ok(libraryElementsDtos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<LibraryElementDto> GetById([FromRoute] int id)
        {
            var libraryElement = _libraryElementService.GetById(id);

            return Ok(libraryElement);
        }

        [HttpGet("keywords")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult<IEnumerable<KeywordDto>> GetAllKeywords()
        {
            var keywords = _dbContext
                .Keyword
                .ToList();

            var keywordDtos = _mapper.Map<List<KeywordDto>>(keywords);

            return Ok(keywordDtos);
        }

        [HttpPost("book")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult CreateBook([FromBody] CreateBookDto dto)
        {
            var id = _libraryElementService.CreateBook(dto);

            return Created($"/api/library/{id}", null);
        }

        [HttpPut("book/{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Update([FromBody] UpdateBookDto dto, [FromRoute] int id)
        {

            _libraryElementService.UpdateBook(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _libraryElementService.Delete(id);

            return NoContent();
        }
    }
}
