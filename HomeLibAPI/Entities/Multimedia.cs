using System;
using System.Security.Policy;

namespace HomeLibraryAPI.Entities
{
    public class Multimedia : LibraryElement
    {
        public TimeSpan Duration { get; set; }
        public string RecordsList { get; set; }
    }
}
