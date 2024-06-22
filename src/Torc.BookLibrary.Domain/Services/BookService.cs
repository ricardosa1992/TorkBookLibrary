using Torc.BookLibrary.Domain.Entities;
using Torc.BookLibrary.Domain.Helpers;
using Torc.BookLibrary.Domain.Interfaces.Repositories;
using Torc.BookLibrary.Domain.Interfaces.Services;
using Torc.BookLibrary.Domain.Parameters;

namespace Torc.BookLibrary.Domain.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    //Here I usually map the result to a Response Model, but for this example I'll keep the entity as a result
    public Task<PaginatedList<Book>> GetAllAsync(GetBooksParameters parameters)
    {
        return _bookRepository.GetAllAsync(parameters);
    }
}