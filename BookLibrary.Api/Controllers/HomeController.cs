using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
      [HttpGet]
      public IActionResult Hello()
      {
        return Ok("Hello World");
      }
    }
}
