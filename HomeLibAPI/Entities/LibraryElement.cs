using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeLibraryAPI.Entities
{
    public class LibraryElement
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Keyword> Keywords { get; set; }

    }
}
