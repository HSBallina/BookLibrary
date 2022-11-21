using BookLibrary.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
  private readonly IAuthorRepository _authorRepository;

  public AuthorsController(IAuthorRepository authorRepository)
  {
    _authorRepository = authorRepository;
  }

  [HttpGet]
  public async Task<IActionResult> List()
  {
    var model = await _authorRepository.List();

    return Ok(model);
  }
}
