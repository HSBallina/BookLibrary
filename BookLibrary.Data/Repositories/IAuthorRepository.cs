﻿using BookLibrary.Common.Dtos;

namespace BookLibrary.Data.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorDto>> List();
        Task<AuthorDetailDto?> GetById(Guid id);
        Task<IEnumerable<AuthorDto>> GetByName(string name);
    }
}
