using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Models
{
    public class LibraryElementDto
    {
        public int Id { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<KeywordDto> Keywords { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public string TableOfContents { get; set; }
        public string Duration { get; set; }
        public string RecordsList { get; set; }
    }
}
