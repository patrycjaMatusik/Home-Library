using HomeLibAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryAPI.Entities
{
    public class HomeLibraryDbContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=HomeLibraryDb;Trusted_Connection=True;";
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<LibraryElement> LibraryElement { get; set; }
        public DbSet<Keyword> Keyword { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Multimedia> Multimedias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Magazine>().ToTable("Magazines");
            modelBuilder.Entity<Multimedia>().ToTable("Multimedias");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
