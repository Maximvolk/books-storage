using Microsoft.EntityFrameworkCore;
using BooksStorage.Core.Models;

namespace BooksStorage.Persistence
{
    public class BooksStorageContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BooksStorageContext(DbContextOptions<BooksStorageContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Author>().ToTable("Author");
            builder.Entity<Author>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Author>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Entity<Author>().HasMany(a => a.Books).WithMany(b => b.Authors).UsingEntity(j => j.ToTable("AuthorBook"));

            builder.Entity<Book>().ToTable("Book");
            builder.Entity<Book>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Entity<Book>().HasMany(b => b.Authors).WithMany(a => a.Books).UsingEntity(j => j.ToTable("AuthorBook"));
        }
    }
}