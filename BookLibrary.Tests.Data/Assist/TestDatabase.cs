using System.Data.Common;
using BookLibrary.Data.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Tests.Data.Assist;

public class TestDatabase
{
  private readonly DbConnection _connection;
  private readonly DbContextOptions<BookDbContext> _options;

  public TestDatabase()
  {
    _connection = new SqliteConnection("Filename=:memory:");
    _connection.Open();

    _options = new DbContextOptionsBuilder<BookDbContext>()
      .UseSqlite(_connection)
      .Options;

    using var context = new BookDbContext(_options);

    context.Database.Migrate();
  }

  public BookDbContext CreateContext() => new(_options);

  public void Dispose() => _connection.Dispose();
}
