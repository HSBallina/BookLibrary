﻿using BookLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Context;

public class BookDbContext : DbContext
{
  public DbSet<Book>? Books { get; set; }
  public DbSet<Genre>? Genres { get; set; }
  public DbSet<Author>? Authors { get; set; }

  public BookDbContext(DbContextOptions<BookDbContext> options)
    : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer("--- from cmd / build ---");
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Author>(b =>
    {
      b.HasKey(c => c.Id);
      b.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
      b.HasMany((c => c.Books));
    });

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
      b.Property(c => c.Description).HasColumnType("nvarchar(100)");
      b.Property(c => c.Purchased).HasColumnType("datetime");
      b.HasOne(c => c.Genre)
        .WithMany(c => c.Books)
        .HasForeignKey(c => c.GenreId)
        .OnDelete(DeleteBehavior.ClientSetNull);
      b.HasOne(c => c.Author)
        .WithMany(c => c.Books)
        .HasForeignKey(c => c.AuthorId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);
    });
  }
}
