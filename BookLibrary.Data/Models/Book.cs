namespace BookLibrary.Data.Models;

public class Book
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public string Author { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public DateTime? Purchased { get; set; } = null;
  public Guid GenreId { get; set; }
  public Genre? Genre { get; set; }
}
