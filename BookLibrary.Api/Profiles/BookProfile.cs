using AutoMapper;
using BookLibrary.Api.ViewModels;
using BookLibrary.Common.Dtos;

namespace BookLibrary.Api.Profiles
{
  public class BookProfile : Profile
  {
    public BookProfile()
    {
      CreateMap<BookDto, BookViewModel>();
    }
  }
}
