namespace Torc.BookLibrary.Domain.Entities;


// I typically create a base class called BaseEntity<TId> to inherit common properties across entities.
// This class includes properties like Id (of type TId) and CreatedAt for timestamping creation.
public class Book
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int TotalCopies { get; set; } = 0;

    public int CopiesInUse { get; set; } = 0;

    public string? Type { get; set; }

    public string? Isbn { get; set; }

    public string? Category { get; set; }
}