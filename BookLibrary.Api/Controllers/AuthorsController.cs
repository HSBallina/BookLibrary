using AutoMapper;
using BookLibrary.Api.ViewModels;
using BookLibrary.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
  private readonly IAuthorRepository _authorRepository;
  private readonly IMapper _mapper;

  public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
  {
    _authorRepository = authorRepository;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<IActionResult> List()
  {
    var model = (await _authorRepository.List())
      .Select(e => _mapper.Map<AuthorViewModel>(e));

    return Ok(model);
  }

  [HttpGet("{id:guid}")]
  public async Task<IActionResult> GetById(Guid id)
  {
    var model = _mapper.Map<AuthorDetailViewModel>(await _authorRepository.GetById(id));

    return model != null ? Ok(model) : NotFound();
  }

  [HttpGet("find/{searchString}")]
  public async Task<IActionResult> Find(string searchString)
  {
    var model = await _authorRepository.GetByName(searchString);

    return Ok(model);
  }
}
