using BookLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Context;

internal class BookDbContext : DbContext
{
  public DbSet<Book>? Cds { get; set; }
  public DbSet<Genre>? Genres { get; set; }

  public BookDbContext(DbContextOptions<BookDbContext> options)
    : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Genre>(b =>
    {
      b.HasKey(c => c.Id);
      b.Property(c => c.Name).HasColumnType("nvarchar(50)");
      b.HasMany(c => c.Books);
    });

    modelBuilder.Entity<Book>(b =>
    {
      b.HasKey(c => c.Id);
      b.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
      b.Property(c => c.Author).HasColumnType("nvarchar(100)").IsRequired();
      b.Property(c => c.Description).HasColumnType("nvarchar(100)");
      b.Property(c => c.Purchased).HasColumnType("datetime");
      b.HasOne(c => c.Genre)
        .WithMany(c => c.Books)
        .HasForeignKey(c => c.GenreId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);
    });
  }
}
