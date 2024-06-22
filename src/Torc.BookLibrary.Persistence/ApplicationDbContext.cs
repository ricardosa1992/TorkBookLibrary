using Microsoft.EntityFrameworkCore;
using Torc.BookLibrary.Domain.Entities;
using Torc.BookLibrary.Persistence.Configurations;

namespace Torc.BookLibrary.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}