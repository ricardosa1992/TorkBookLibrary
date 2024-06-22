using Torc.BookLibrary.Domain.Entities;
using Torc.BookLibrary.Domain.Helpers;
using Torc.BookLibrary.Domain.Parameters;

namespace Torc.BookLibrary.Domain.Interfaces.Repositories;

public interface IBookRepository
{
    Task<PaginatedList<Book>> GetAllAsync(GetBooksParameters parameters);
}