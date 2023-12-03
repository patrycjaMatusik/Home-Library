using AutoMapper;
using HomeLibAPI.Exceptions;
using HomeLibAPI.Models;
using HomeLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Services
{
    public interface ILibraryElementService
    {
        List<LibraryElementDto> GetAll(LibraryObjectQuery query);
        LibraryElementDto GetById(int id);

        int CreateBook(CreateBookDto dto);
        void UpdateBook(int id, UpdateBookDto dto);

        void Delete(int id);
    }
    public class LibraryElementService : ILibraryElementService
    {
        private readonly HomeLibraryDbContext _dbContext;
        private readonly IMapper _mapper;
        public LibraryElementService(HomeLibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int CreateBook(CreateBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public void UpdateBook(int id, UpdateBookDto dto)
        {
            var book = _dbContext
                .Books
                .FirstOrDefault(r => r.Id == id);

            if (book is null)
                throw new NotFoundException("Book not found");

            book.Title = dto.Title;
            book.Description = dto.Description;
            book.NumberOfPages = dto.NumberOfPages;
            book.ISBN = dto.ISBN;
            book.TableOfContents = dto.TableOfContents;
            book.AuthorId = dto.AuthorId;
            book.PublisherId = dto.PublisherId;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var libraryElement = _dbContext
                .LibraryElement
                .FirstOrDefault(r => r.Id == id);

            if (libraryElement is null)
                throw new NotFoundException("Library element not found");

            _dbContext.LibraryElement.Remove(libraryElement);
            _dbContext.SaveChanges();
        }

        public LibraryElementDto GetById(int id)
        {

            var libraryElement = _dbContext
                .LibraryElement
                .Include(r => r.Author)
                .Include(r => r.Publisher)
                .Include(r => r.Keywords)
                .FirstOrDefault(r => r.Id == id);

            if (libraryElement is null)
            {
                throw new NotFoundException("Library element not found");
            }

            var libraryElementsDto = _mapper.Map<LibraryElementDto>(libraryElement);

            return libraryElementsDto;
        }

        public List<LibraryElementDto> GetAll(LibraryObjectQuery query)
        {
            var querable = _dbContext.LibraryElement.AsQueryable();

            if (query.LibraryObjectType != null)
            {
                switch (query.LibraryObjectType)
                {
                    case "Book": querable = querable.OfType<Book>();
                        break;
                    case "Magazine": querable = querable.OfType<Magazine>();
                        break;
                    case "Multimedia" : querable = querable.OfType<Multimedia>();
                        break;
                }
            }

            if (query.AuthorId > 0)
            {
                querable = querable.Where(le => le.AuthorId == query.AuthorId);
            }
            if (query.PublisherId > 0)
            {
                querable = querable.Where(le => le.PublisherId == query.PublisherId);
            }
            if (query.KeywordId > 0)
            {
                querable = querable.Where(le => le.Keywords.Any(k=> k.Id == query.KeywordId));
            }

            var libraryElements = querable
                .Include(le => le.Author)
                .Include(le => le.Publisher)
                .Include(le => le.Keywords)
                .ToList();

            var libraryElementsDtos = _mapper.Map<List<LibraryElementDto>>(libraryElements);

            return libraryElementsDtos;
        }
    }
}
