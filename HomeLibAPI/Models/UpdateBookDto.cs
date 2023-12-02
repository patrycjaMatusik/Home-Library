using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Models
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public string TableOfContents { get; set; }

        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
