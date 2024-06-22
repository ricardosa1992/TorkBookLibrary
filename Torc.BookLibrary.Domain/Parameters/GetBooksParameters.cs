using Torc.BookLibrary.Domain.Helpers;

namespace Torc.BookLibrary.Domain.Parameters;

public class GetBooksParameters : PaginationParameters
{
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public string? Title { get; set; }
}