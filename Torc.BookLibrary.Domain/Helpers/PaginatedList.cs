using Microsoft.EntityFrameworkCore;

namespace Torc.BookLibrary.Domain.Helpers;

public class PaginatedList<T> 
{
    public PaginatedList() => this.Items = Enumerable.Empty<T>();

    public PaginatedList(long totalItems, IEnumerable<T> items)
    {
        this.TotalItems = totalItems;
        this.Items = items;
    }

    public long TotalItems { get; set; }

    public IEnumerable<T> Items { get; set; }

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(count, items);
    }
}