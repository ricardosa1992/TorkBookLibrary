using Microsoft.EntityFrameworkCore;
using Torc.BookLibrary.Domain.Entities;
using Torc.BookLibrary.Domain.Helpers;
using Torc.BookLibrary.Domain.Interfaces.Repositories;
using Torc.BookLibrary.Domain.Parameters;

namespace Torc.BookLibrary.Persistence.Repositories;

// I commonly create a class named RepositoryBase to abstract common operations such as GetAll with predicate parameters,
// Save, Update, and other CRUD operations, providing a reusable foundation for working with data access in the application.
public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    //Here we could use Dapper to be faster, or use raw queries with EF
    //Using StartsWith is more performance than Contains 
    public async Task<PaginatedList<Book>> GetAllAsync(GetBooksParameters parameters)
    {
        var query = _context.Books.AsNoTracking();

        //I create a composite Index for these fields for improving performance
        if (!string.IsNullOrEmpty(parameters.Author))
        {
            query = query.Where(b => (b.FirstName + " " + b.LastName).StartsWith(parameters.Author));
        }

        if (!string.IsNullOrEmpty(parameters.Isbn))
        {
            query = query.Where(b => b.Isbn.StartsWith(parameters.Isbn));
        }

        if (!string.IsNullOrEmpty(parameters.Title))
        {
            query = query.Where(b => b.Title.StartsWith(parameters.Title));
        }

        return await PaginatedList<Book>.CreateAsync(query, parameters.PageNumber, parameters.PageSize);
    }
}