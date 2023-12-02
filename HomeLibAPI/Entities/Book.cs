namespace HomeLibraryAPI.Entities
{
    public class Book : LibraryElement
    {
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public string TableOfContents { get; set; }
    }
}
