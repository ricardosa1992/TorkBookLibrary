using Microsoft.AspNetCore.Mvc;
using Torc.BookLibrary.Domain.Entities;
using Torc.BookLibrary.Domain.Helpers;
using Torc.BookLibrary.Domain.Interfaces.Services;
using Torc.BookLibrary.Domain.Parameters;

namespace Torc.BookLibrary.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedList<Book>), StatusCodes.Status200OK)]
    public Task<PaginatedList<Book>> Get([FromQuery] GetBooksParameters parameters)
    {
        return _bookService.GetAllAsync(parameters);
    }
}