using Microsoft.EntityFrameworkCore;
using LibraryManagment.Api.Models;

namespace LibraryManagment.Api.Database
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }
    

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity => {
                entity.HasKey(e => e.Id);

                entity.ToTable("Books", "dbo");

                entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsRequired();

                entity.Property(e => e.IsCheckedOut)
                .IsRequired();
            });

            modelBuilder.Entity<Patron>(entity => {
                entity.HasKey(e => e.PatronId);

                entity.ToTable("Patrons", "dbo");

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            });
        }
    }
}