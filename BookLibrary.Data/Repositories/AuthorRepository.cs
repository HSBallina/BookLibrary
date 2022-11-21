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
    if (_context.Authors == null) return new List<AuthorDto>();

    return await _context.Authors
      .OrderBy(c => c.Name)
      .Select(c => _mapper.Map<AuthorDto>(c))
      .ToListAsync();
  }
}
