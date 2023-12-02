using AutoMapper;
using HomeLibAPI.Models;
using HomeLibraryAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI
{
    public class HomeLibraryMappingProfile : Profile
    {
        public HomeLibraryMappingProfile()
        {
            CreateMap<Author, AuthorDto>();

            CreateMap<Publisher, PublisherDto>();

            CreateMap<Keyword, KeywordDto>();

            CreateMap<LibraryElement, LibraryElementDto>();

            CreateMap<CreateBookDto, Book>();
        }
    }
}
