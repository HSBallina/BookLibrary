namespace BookLibrary.Api.ViewModels;

public class AuthorDetailViewModel : AuthorViewModel
{
  public IEnumerable<BookViewModel>? Books { get; set; }
}
