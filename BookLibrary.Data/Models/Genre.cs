namespace BookLibrary.Data.Models;

public class Genre
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public IEnumerable<Book>? Books { get; set; }
}
