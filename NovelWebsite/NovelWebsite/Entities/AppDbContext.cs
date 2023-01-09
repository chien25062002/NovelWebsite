using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;

namespace NovelWebsite.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<BookStatus> bookStatuses { get; set; }
        public DbSet<Book> books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<BookStatus>().ToTable("BookStatus");
            modelBuilder.Entity<Book>().ToTable("Books");
        }
    }

}
