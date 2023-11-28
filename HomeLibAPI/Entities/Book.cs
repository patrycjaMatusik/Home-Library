namespace HomeLibraryAPI.Entities
{
    public class Book : LibraryElement
    {
        public int PublisherId { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public string TableOfContents { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
