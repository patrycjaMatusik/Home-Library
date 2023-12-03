using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibAPI.Models
{
    public class LibraryObjectQuery
    {
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string LibraryObjectType { get; set; }
        public int KeywordId { get; set; }
    }
}
