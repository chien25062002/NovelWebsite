using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;

namespace NovelWebsite.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FollowingBook> FollowingBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<BookStatus>().ToTable("BookStatus");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<BookTag>().ToTable("BookTags");
            modelBuilder.Entity<Chapter>().ToTable("Chapters");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<FollowingBook>().ToTable("FollowingBooks").HasKey(k => new {k.User, k.Book});
            base.OnModelCreating(modelBuilder);
        }
    }

}
