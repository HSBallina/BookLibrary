namespace BookLibrary.Data.Models;

public class Book
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public DateTime? Purchased { get; set; } = null;
  public Guid? GenreId { get; set; }
  public virtual Genre? Genre { get; set; }
  public Guid AuthorId { get; set; }
  public virtual Author? Author { get; set; }
}
