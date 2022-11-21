using AutoMapper;
using BookLibrary.Common.Dtos;
using BookLibrary.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data.Repositories;

public class AuthorRepository : IAuthorRepository
{
  private readonly BookDbContext _context;
  private readonly IMapper _mapper;

  public AuthorRepository(BookDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<IEnumerable<AuthorDto>> List()
  {
    if (_context.Authors == null) throw new ApplicationException("Can't reach the database");

    return await _context.Authors
      .OrderBy(c => c.Name)
      .Select(c => _mapper.Map<AuthorDto>(c))
      .ToListAsync();
  }

  public async Task<AuthorDetailDto?> GetById(Guid id)
  {
    if (_context.Authors == null) throw new ApplicationException("Can't reach the database");

    var author = await _context.Authors
      .Include(e => e.Books)
      .Where(c => c.Id == id)
      .FirstOrDefaultAsync();

    return author == null
      ? null
      : _mapper.Map<AuthorDetailDto>(author);
  }

  public async Task<IEnumerable<AuthorDto>> GetByName(string name)
  {
    if (_context.Authors == null) throw new ApplicationException("Can't reach the database");

    return await _context.Authors
        .Where(c => c.Name.Contains(name))
        .OrderBy(c => c.Name)
        .Select(c => _mapper.Map<AuthorDto>(c))
        .ToListAsync();
  }
}
