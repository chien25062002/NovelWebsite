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
        public DbSet<TagEntity> BookTags { get; set; }
        public DbSet<ChapterEntity> Chapters { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<BookUserEntity> BookUsers { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> UserRoles { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().ToTable("Category");
            modelBuilder.Entity<AuthorEntity>().ToTable("Author");
            modelBuilder.Entity<BookStatusEntity>().ToTable("BookStatus");
            modelBuilder.Entity<BookEntity>().ToTable("Book");
            modelBuilder.Entity<AccountEntity>().ToTable("Account");
            modelBuilder.Entity<TagEntity>().ToTable("Tag");
            modelBuilder.Entity<ChapterEntity>().ToTable("Chapter");
            modelBuilder.Entity<CommentEntity>().ToTable("Comment");
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<RoleEntity>().ToTable("Role");
            modelBuilder.Entity<PostEntity>().ToTable("Post");
            modelBuilder.Entity<BookUserEntity>().ToTable("BookUser").HasNoKey();
            modelBuilder.Entity<ReviewEntity>().ToTable("Review");
            base.OnModelCreating(modelBuilder);
        }
    }

}
