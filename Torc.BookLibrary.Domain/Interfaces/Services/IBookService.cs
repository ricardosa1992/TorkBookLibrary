using Torc.BookLibrary.Domain.Entities;
using Torc.BookLibrary.Domain.Helpers;
using Torc.BookLibrary.Domain.Parameters;

namespace Torc.BookLibrary.Domain.Interfaces.Services;

public interface IBookService
{
    Task<PaginatedList<Book>> GetAllAsync(GetBooksParameters parameters);
}