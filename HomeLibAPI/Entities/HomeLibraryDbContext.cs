using Microsoft.EntityFrameworkCore;

namespace HomeLibraryAPI.Entities
{
    public class HomeLibraryDbContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=HomeLibraryDb;Trusted_Connection=True;";
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<RecordLabel> RecordLabels { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Magazine>().ToTable("Magazines");
            modelBuilder.Entity<Multimedia>().ToTable("Multimedias");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
