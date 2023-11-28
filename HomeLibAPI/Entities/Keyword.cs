using System.Collections.Generic;

namespace HomeLibraryAPI.Entities
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<LibraryElement> LibraryElements { get; set; }
    }
}
