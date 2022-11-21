using AutoMapper;
using BookLibrary.Common.Dtos;
using BookLibrary.Data.Models;

namespace BookLibrary.Data.Profiles;

public class AuthorProfile : Profile
{
  public AuthorProfile()
  {
    CreateMap<Author, AuthorDto>();

    CreateMap<AuthorDto, Author>()
      .ForMember(d => d.Books, o => o.Ignore());
  }
}
