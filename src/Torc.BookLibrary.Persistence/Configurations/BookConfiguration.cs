using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Torc.BookLibrary.Domain.Entities;

namespace Torc.BookLibrary.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");

        builder.HasKey(b => b.BookId);

        builder.Property(b => b.BookId)
            .HasColumnName("book_id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Title)
            .HasColumnName("title")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.FirstName)
            .HasColumnName("first_name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.LastName)
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.TotalCopies)
            .HasColumnName("total_copies")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(b => b.CopiesInUse)
            .HasColumnName("copies_in_use")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(b => b.Type)
            .HasColumnName("type")
            .HasMaxLength(50);

        builder.Property(b => b.Isbn)
            .HasColumnName("isbn")
            .HasMaxLength(80);

        builder.Property(b => b.Category)
            .HasColumnName("category")
            .HasMaxLength(50);

        builder.HasIndex(b => new { b.FirstName, b.LastName }).HasDatabaseName("IX_Books_FirstName_LastName");
    }
}