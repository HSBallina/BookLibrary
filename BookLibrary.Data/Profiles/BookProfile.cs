using AutoMapper;
using BookLibrary.Common.Dtos;
using BookLibrary.Data.Models;

namespace BookLibrary.Data.Profiles;

public class BookProfile : Profile
{
  public BookProfile()
  {
    CreateMap<Book, BookDto>();

    CreateMap<BookDto, Book>()
      .ForMember(d => d.Author, o => o.Ignore());
  }
}
