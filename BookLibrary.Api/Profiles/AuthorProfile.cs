using AutoMapper;
using BookLibrary.Api.ViewModels;
using BookLibrary.Common.Dtos;

namespace BookLibrary.Api.Profiles;

public class AuthorProfile : Profile
{
  public AuthorProfile()
  {
    CreateMap<AuthorDto, AuthorViewModel>();

    CreateMap<AuthorDetailDto, AuthorDetailViewModel>();
  }
}