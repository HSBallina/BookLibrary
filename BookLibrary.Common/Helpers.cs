using AutoMapper;

namespace BookLibrary.Common;

public static class Helpers
{
  public static IMapper GetMapper(IEnumerable<Profile> profiles)
  {
    var config = new MapperConfiguration(cfg =>
    {
      cfg.AddProfiles(profiles);
    });

    return new Mapper(config);
  }
}
