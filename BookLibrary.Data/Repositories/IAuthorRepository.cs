using BookLibrary.Common.Dtos;

namespace BookLibrary.Data.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorDto>> List();
    }
}
