namespace BookLibrary.Tests.Data;

[TestFixture(Category = "Data")]
public class AuthorTests
{
  private IAuthorRepository _repository = null!;
  private BookDbContext _context = null!;
  private readonly TestDatabase _database;
  private readonly List<Author> _authors;
  private readonly IMapper _mapper;

  public AuthorTests()
  {
    _database = new TestDatabase();

    var testAuthors = new Faker<Author>();
    testAuthors
      .RuleFor(e => e.Id, f => f.Random.Guid())
      .RuleFor(e => e.Name, f => f.Name.FullName());
    _authors = testAuthors.Generate(20);

    _mapper = Helpers.GetMapper(new[] { new AuthorProfile() });
  }

  [SetUp]
  public void Setup()
  {
    _context = _database.CreateContext();
    _context.Database.ExecuteSqlRaw("delete from Authors");
    _repository = new AuthorRepository(_context, _mapper);
  }

  [Test]
  public async Task GetShouldReturnLocation()
  {
    _context.Authors!.AddRange(_authors);
    await _context.SaveChangesAsync();

    var expected = _mapper.Map<AuthorDto>(_authors[3]);
    var actual = await _repository.GetById(expected.Id);

    Assert.Multiple(() =>
    {
      Assert.That(actual, Is.Not.Null);
      Assert.That(actual, Is.AssignableFrom<AuthorDto>());
      Assert.That(actual!.Id, Is.EqualTo(expected.Id));
      Assert.That(actual.Name, Is.EqualTo(expected.Name));
    });
  }
}
