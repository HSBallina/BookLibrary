namespace BookLibrary.Common.Dtos;

public class AuthorDetailDto : AuthorDto
{
  public AuthorDetailDto(Guid id, string name) : base(id, name)
  {
    Books = new List<BookDto>();
  }

  public IEnumerable<BookDto> Books { get; set; }
}
