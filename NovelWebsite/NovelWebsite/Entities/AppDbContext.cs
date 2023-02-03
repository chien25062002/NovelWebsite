using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;

namespace NovelWebsite.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookStatusEntity> BookStatuses { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<BookTagEntity> BookTags { get; set; }
        public DbSet<ChapterEntity> Chapters { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<FollowingBookEntity> FollowingBooks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().ToTable("Categories");
            modelBuilder.Entity<AuthorEntity>().ToTable("Authors");
            modelBuilder.Entity<BookStatusEntity>().ToTable("BookStatus");
            modelBuilder.Entity<BookEntity>().ToTable("Books");
            modelBuilder.Entity<AccountEntity>().ToTable("Accounts");
            modelBuilder.Entity<BookTagEntity>().ToTable("BookTags");
            modelBuilder.Entity<ChapterEntity>().ToTable("Chapters");
            modelBuilder.Entity<CommentEntity>().ToTable("Comments");
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<UserRoleEntity>().ToTable("UserRoles");
            modelBuilder.Entity<PostEntity>().ToTable("Post");
            modelBuilder.Entity<FollowingBookEntity>().ToTable("Following_Books").HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }

}
