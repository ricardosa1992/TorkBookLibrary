using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torc.BookLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeIndexForFirstAndLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_FirstName_LastName",
                table: "books",
                columns: new[] { "first_name", "last_name" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_FirstName_LastName",
                table: "books");
        }
    }
}
