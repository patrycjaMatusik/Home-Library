using System;

namespace HomeLibraryAPI.Entities
{
    public class Multimedia : LibraryElement
    {
        public int RecordLabelId { get; set; }
        public virtual RecordLabel RecordLabel { get; set; }
        public TimeSpan Duration { get; set; }
        public string RecordsList { get; set; }
    }
}
