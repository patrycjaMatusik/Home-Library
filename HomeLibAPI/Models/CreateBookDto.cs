using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Models
{
    public class CreateBookDto
    {
        [Required]
        [MaxLength(256)]

        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public string TableOfContents { get; set; }

        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
