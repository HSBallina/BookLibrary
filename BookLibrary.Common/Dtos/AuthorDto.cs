namespace BookLibrary.Common.Dtos
{
  public class AuthorDto
  {
    public AuthorDto(Guid id, string name)
    {
      Id = id;
      Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
    public override int GetHashCode() => (Id, Name).GetHashCode();
    public override bool Equals(object? other)
      => other is AuthorDto e && (e.Id, e.Name).Equals((Id, Name));
    public override string ToString() => $"{Id}, {Name}";
  }
}
